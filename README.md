# NeST
**LITTLE-ENDIAN ONLY FOR NOW**

## About
NeST is a library for quickly serializing and deserializing arrays of bytes, intended for use at different ends of a network. NeST does not allocate memory for byte buffers, meaning if you have byte array network buffers, you can just pass those around.

This is meant mainly for the Unity engine, but it does not have any hard Unity dependencies.

## How can I use it?

Place it inside a folder inside Assets/, or clone as a submodule. If you aren't using Unity, you will need to make sure this module is compiled with 'unsafe' code enabled. The unsafe directive is used for serialization of primitive types.

Now, here's how you use it in your program:

### ByteArray

ByteArray is a wrapper class for byte arrays. It stores a position and a length which you can change. ByteArrays are passed to writer and reader functions to safely write and read bytes.

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

The function signatures are defined in Writers.cs and Readers.cs as ``delegate void Writer<T>(T value, ByteArray array);`` and ``delegate T Reader<T>(ByteArray array);``. You can write your own serialization methods using these signatures.

As an example, here is a writer function for Unity's Vector3 class.

```cs
public void WriteVector3(Vector3 input, ByteArray array)
{
        // We can throw without writing to the array since we know how big our
        // serialized object will be in memory ahead of time.
        if (!array.Has(12)) throw new IndexOutOfRangeException();

        // Writing to a ByteArray increments it's internal position. WriteFloat
        // here increment it's position by 4 each time.
        Writers.WriteFloat(input.x, array);
        Writers.WriteFloat(input.y, array);
        Writers.WriteFloat(input.z, array);
}
```

And here's a reader.

```cs
public Vector3 ReadVector3(ByteArray array)
{
        if (!array.Has(12)) throw new IndexOutOfRangeException();
        var vector = Vector3.zero;
        vector.x = Readers.ReadFloat(array);
        vector.y = Readers.ReadFloat(array);
        vector.z = Readers.ReadFloat(array);
        return vector;
}
```

And that's it! Read and write operations may end up throwing an IndexOutOfRange exception.

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
                serializer.SerializeUsing(
                        First, Writers.WriteFloat,
                        Second, Writers.WriteInt,
                        Third, Writers.WriteByte
                );
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