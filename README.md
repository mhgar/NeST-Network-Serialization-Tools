# NeST
**LITTLE-ENDIAN ONLY FOR NOW**

## About
NeST is a library for quickly serializing and deserializing arrays of bytes, intended for use at different ends of a network. NeST does not allocate memory for byte buffers, meaning if you have byte array network buffers, you can just pass those around.

## How can I use it?

Place it inside your Assets folder in Unity. If you aren't using Unity, you will need to make sure this module is compiled with 'unsafe' code enabled. The unsafe directive is used for serialization of primitive types.

Now, here's how you use it in your program:

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

        Writers.WriteFloat(input.x, array, index);
        Writers.WriteFloat(input.y, array, index + 4);
        Writers.WriteFloat(input.z, array, index + 8);

        // The writer functions return the bytes written, so we could return the
        // sum of those if we really wanted to be safe.
        return 12;
}
```

And that's it!

## How do I use ISerializable?

Like this:

```cs
struct SerializedStruct : ISerializable
{
        public float First;
        public int Second;
        public byte Third;

        public void DeserializeFrom(Deserializer deserializer)
        {
                First = deserializer.DeserializeUsing<float>(Readers.ReadFloat);
                Second = deserializer.DeserializeUsing<int>(Readers.ReadInt);
                Third = deserializer.DeserializeUsing<byte>(Readers.ReadByte);
        }

        public void SerializeTo(Serializer serializer)
        {
                serializer.SerializeUsing(First, Writers.WriteFloat);
                serializer.SerializeUsing(Second, Writers.WriteInt);
                serializer.SerializeUsing(Third, Writers.WriteByte);
        }
}
```

The ``Serializer`` and ``Deserializer`` objects pass themselves to the respective functions which neatly allows you to use the same facilities that you used to call the serialization in the first place.

You can then use ``SerializedStruct`` like this:

```cs
serializer.Serialize<SerializedStruct>(serializedStruct);

// ... somewhere on another computer ...

var serializedStruct = deserializer.Deserialize<SerializedStruct>(serializedStruct);
```