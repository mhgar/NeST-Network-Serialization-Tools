# NeST

## About
NeST is a library for quickly serializing and deserializing arrays of bytes, intended for use at different ends of a network. NeST does not allocate memory for byte buffers, meaning if you have byte array network buffers, you can just pass those around.

## How can I use it?

Like this:

### Deserialization

Reading an object that implements ISerializable, with the interface's methods implemented.
```cs
var output = deserializer.Deserialize<SerializableClass>();
```

Reading a single variable (in this case an integer).
```cs
var output = deserializer.DeserializeUsing<int>(Readers.ReadInt);
```

Reading multiple variables at a time without a predefined ISerializable.
```cs
var output = deserializer.DeserializeUsing<float, int, byte>(
        Readers.ReadFloat,
        Readers.ReadInt,
        Readers.ReadByte
);
// typeof(output.b) == typeof(int)
```

### Serialization

Writing an object that implements ISerializable.
```cs
serializer.Serialize<SerializableClass>(myObject);
```

Writing a single variable. For extra safety, explicity write <> syntax.
```cs
serializer.SerializeUsing<int>(64, Writers.WriteInt);
```

Writing multiple variables at a time.
```cs
serializer.SerializeUsing<float, int, byte>(
        1024f, Writers.WriteFloat,
        512, Writers.WriteInt,
        255, Writers.WriteByte
);
```

## What are writers and readers?

Writers and readers are passed functions that contain the serialization or deserialization implementation. This makes it very easy to add your own serialization functionality on a case by case basis.

The function signatures are defined in Writers.cs and Readers.cs as ``delegate int Writer<T>(T value, byte[] array, int index = 0);`` and ``delegate int Reader<T>(out T value, byte[] array, int index = 0);``. You can write your own serialization methods using these signatures.

As an example, here is a writer function for Unity's Vector3 class.

```cs
public int WriteVector3(Vector3 input, byte[] array, int index = 0)
{
        // We can throw without writing to the array since we know how big our
        // serialized object will be in memory ahead of time.
        if (index + 12 > array.Length) throw new IndexOutOfRangeException();

        index += Writers.WriteFloat(input.x, array, index);
        index += Writers.WriteFloat(input.y, array, index);
        Writers.WriteFloat(input.z, array, index);

        // The writer functions return the bytes written, so we could return the
        // sum of those if we really wanted to be safe.
        return 12;
}
```

And that's it!



