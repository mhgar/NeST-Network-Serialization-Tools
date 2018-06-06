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

  [TestCase(new byte[] { 0, 0, 0, 0x43, 0x40, 0, 0, 0, 0x20 }, 128f, 64, 32)]
  public void DeserializerObject(byte[] input, float first, int second, byte third)
  {
    var deserializer = new Deserializer(input);

    var output = deserializer.Deserialize<SerializedStruct>();

    Assert.That(output.First == first && 
                output.Second == second && 
                output.Third == third,
                "Output did not have the correct values."
    );
  }
}