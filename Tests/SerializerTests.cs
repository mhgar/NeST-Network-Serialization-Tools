using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

using Wander.NeST;

public class SerializerTests 
{
  struct SerializedStruct : ISerializable
  {
    public float First;
    public int Second;
    public byte Third;

    public void DeserializeFrom(Deserializer deserializer)
    {
      throw new NotImplementedException();
    }

    public void SerializeTo(Serializer serializer)
    {
      serializer.SerializeUsing(First, Writers.WriteFloat);
      serializer.SerializeUsing(Second, Writers.WriteInt);
      serializer.SerializeUsing(Third, Writers.WriteByte);
    }
  }

  bool CompareArray(byte[] a, byte[] b)
  {
    if (a.Length != b.Length)
      throw new System.ArgumentException("Arrays must be same length");

    for (int i = 0; i < a.Length; i++) if 
      (a[i] != b[i]) 
        return false;
    return true;
  }

  string PrintArray(byte[] array)
  {
    string output = "";
    foreach(var b in array) { output += string.Format("{0:X} ", b); };
    return output;
  }

  [TestCase(new byte[] { 0x40, 0, 0, 0 }, 64)]
  public void SerializeInteger(byte[] expected, int value)
  {
    var buffer = new byte[4];
    var serializer = new Serializer(new ByteArray(buffer));

    serializer.SerializeUsing(value, Writers.WriteInt);

    Assert.That(
      CompareArray(serializer.Internal, expected),
      "The serialization result is different than expected.\n"+
      "Got: " + PrintArray(serializer.Internal) + "\nExpected: " + 
      PrintArray(expected)
    );
    Assert.That(!serializer.HasData, "Serializer still has data.");
  }

  [TestCase(new byte[] { 0, 0, 0, 0x43, 0x40, 0, 0, 0, 0x20 }, 128f, 64, 32)]
  public void SerializeISerializable(byte[] expected, float first, int second, byte third)
  {
    var buffer = new byte[9];
    var serializer = new Serializer(new ByteArray(buffer));
    var structure = new SerializedStruct() { First = first, Second = second, Third = third };

    serializer.Serialize(structure);

    Assert.That(
      CompareArray(serializer.Internal, expected),
      "The serialization result is different than expected.\n"+
      "Got: " + PrintArray(serializer.Internal) + "\nExpected: " + 
      PrintArray(expected)
    );
    Assert.That(!serializer.HasData, "Serializer still has data.");
  }

  [TestCase(new byte[] { 0, 0, 0, 0x43, 0x40, 0, 0, 0, 0x20 }, 128f, 64, 32)]
  public void SerializeGeneric(byte[] expected, float a, int b, byte c)
  {
    var buffer = new byte[9];
    var serializer = new Serializer(new ByteArray(buffer));

    serializer.SerializeUsing<float, int, byte>(
      a, Writers.WriteFloat,
      b, Writers.WriteInt,
      c, Writers.WriteByte
    );

    Assert.That(
      CompareArray(serializer.Internal, expected),
      "The serialization result is different than expected.\n"+
      "Got: " + PrintArray(serializer.Internal) + "\nExpected: " + 
      PrintArray(expected)
    );
    Assert.That(!serializer.HasData, "Serializer still has data.");
  }
}