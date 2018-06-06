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

  public bool CompareArray(byte[] a, byte[] b)
  {
    if (a.Length != b.Length)
      throw new System.ArgumentException("Arrays must be same length");

    for (int i = 0; i < a.Length; i++) if 
      (a[i] != b[i]) 
        return false;
    return true;
  }

  [TestCase(new byte[] { 0, 0, 0, 0x43, 0x40, 0, 0, 0, 0x20 }, 128f, 64, 32)]
  public void SerializerObject(byte[] expected, float first, int second, byte third)
  {
    var buffer = new byte[9];
    var serializer = new Serializer(buffer);
    var structure = new SerializedStruct() { First = first, Second = second, Third = third };

    serializer.Serialize(structure);

    Assert.That(
      CompareArray(serializer.Array, expected),
      "The serialization result is different than expected."
    );
  }
}