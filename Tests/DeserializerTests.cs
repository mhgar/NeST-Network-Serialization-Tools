using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

using Wander.NeST;

public class DeserializerTests 
{
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
      throw new NotImplementedException();
    }
  }

  public bool CompareArray(byte[] a, byte[] b)
  {
    if (a.Length != b.Length)
      throw new System.ArgumentException("Arrays must be same length");

    for (int i = 0; i < a.Length; i++) if 
      (a[i] != b[i]) 
        return false;
    return true;
  }

  [TestCase(new byte[] { 0x40, 0, 0, 0 }, 64)]
  public void DeerializeInteger(byte[] input, int expected)
  {
    var deserializer = new Deserializer(new ByteArray(input));
    var got = deserializer.DeserializeUsing<int>(Readers.ReadInt);    

    Assert.AreEqual(expected, got, "The deserialization result is different than expected.");
    Assert.That(!deserializer.HasData, "Deserializer still has data.");
  }

  [TestCase(new byte[] { 0, 0, 0, 0x43, 0x40, 0, 0, 0, 0x20 }, 128f, 64, 32)]
  public void DeserializeISerializable(byte[] input, float first, int second, byte third)
  {
    var deserializer = new Deserializer(new ByteArray(input));

    var output = deserializer.Deserialize<SerializedStruct>();

    Assert.AreEqual(first, output.First, "Received incorrect 'First' value.");
    Assert.AreEqual(second, output.Second, "Received incorrect 'Second' value.");
    Assert.AreEqual(third, output.Third, "Received incorrect 'Third' value.");
    Assert.That(!deserializer.HasData, "Deserializer still has data.");
  }

  [TestCase(new byte[] { 0, 0, 0, 0x43, 0x40, 0, 0, 0, 0x20 }, 128f, 64, 32)]
  public void DeserializeGeneric(byte[] input, float a, int b, byte c)
  {
    var deserializer = new Deserializer(new ByteArray(input));

    var output = deserializer.DeserializeUsing<float, int, byte>(
      Readers.ReadFloat,
      Readers.ReadInt,
      Readers.ReadByte
    );

    Assert.AreEqual(a, output.a, "Received incorrect 'A' value.");
    Assert.AreEqual(b, output.b, "Received incorrect 'B' value.");
    Assert.AreEqual(c, output.c, "Received incorrect 'C' value.");
    Assert.That(!deserializer.HasData, "Deserializer still has data.");
  }
}