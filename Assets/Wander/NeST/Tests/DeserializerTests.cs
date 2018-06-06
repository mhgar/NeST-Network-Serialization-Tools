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

    public int DeserializeFrom(byte[] array, int index = 0)
    {
      if (index + 9 > array.Length)
        return 0;

      index += Readers.ReadFloat(out First, array, index);
      index += Readers.ReadInt(out Second, array, index);
      index += Readers.ReadByte(out Third, array, index);

      return 9;
    }

    public void DeserializeFrom(Deserializer deserializer)
    {
      deserializer.Deserialize
    }

    public int SerializeTo(byte[] array, int index = 0)
    {
      throw new NotImplementedException();
      /*
      if (index + 9 > array.Length)
        return 0;

      index += Writers.WriteFloat(First, array, index);
      index += Writers.WriteInt(Second, array, index);
      index += Writers.WriteByte(Third, array, index);

      return 9;
      */
    }
  }

  const float PreFirst = 128f;
  const int PreSecond = 64;
  const byte PreThird = 32;

  static SerializedStruct preInitialized = new SerializedStruct() {
    First = PreFirst,
    Second = PreSecond,
    Third = PreThird
  };

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
  public void DeserializeStructManually(byte[] input, float first, int second, byte third)
  {
    var output = new SerializedStruct();

    var wrote = output.DeserializeFrom(input, 0);

    Assert.That(wrote == 9, "Didn't write 9 bytes.");
    Assert.That(output.First == first && 
                output.Second == second && 
                output.Third == third,
                "Output did not have the correct values."
    );
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