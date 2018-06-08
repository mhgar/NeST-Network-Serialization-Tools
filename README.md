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


