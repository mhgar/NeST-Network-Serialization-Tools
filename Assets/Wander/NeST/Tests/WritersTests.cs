using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

using Wander.NeST;

public class WritersTests
{
  public bool CompareArray(byte[] a, byte[] b)
  {
    if (a.Length != b.Length)
      throw new System.ArgumentException("Arrays must be same length");

    for (int i = 0; i < a.Length; i++) if 
      (a[i] != b[i]) 
        return false;
    return true;
  }

  [TestCase(6, new byte[] { 0, 6, 0, 0, 0, 0, 0, 0, 0 }, 1)] // Write 6 from position 1
  public void WriteByte(byte value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteByte(value, array, startIndex);
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(6, new byte[] { 0, 6, 0, 0, 0, 0, 0, 0, 0 }, 1)] // Write 6 from position 1
  public void WriteSByte(sbyte value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteSByte(value, array, startIndex);
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase('a', new byte[] { 0, (byte) 'a', 0, 0, 0, 0, 0, 0, 0 }, 1)] // Write 6 from position 1
  public void WriteChar(char value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteChar(value, array, startIndex);
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xAB, new byte[] { 0, 0xAB, 0, 0, 0, 0, 0, 0, 0 }, 1)] // Write 6 from position 1
  public void WriteShort(long value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteShort((short) value, array, startIndex);


    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xAB, new byte[] { 0, 0xAB, 0, 0, 0, 0, 0, 0, 0 }, 1)] // Write 6 from position 1
  public void WriteUShort(long value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteUShort((ushort) value, array, startIndex);
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xABAB, new byte[] { 0, 0xAB, 0xAB, 0, 0, 0, 0, 0, 0 }, 1)] // Write 6 from position 1
  public void WriteInt(long value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteInt((int) value, array, startIndex);
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(1023f, new byte[] { 0, 0x00, 0xc0, 0x7f, 0x44, 0, 0, 0, 0 }, 1)] // Write 6 from position 1
  public void WriteFloat(float value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteFloat(value, array, startIndex);
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xABAB, new byte[] { 0, 0xAB, 0xAB, 0, 0, 0, 0, 0, 0 }, 1)] // Write 6 from position 1
  public void WriteUInt(long value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteUInt((uint) value, array, startIndex);
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xABABABAB, new byte[] { 0, 0xAB, 0xAB, 0xAB, 0xAB, 0, 0, 0, 0 }, 1)] // Write 6 from position 1
  public void WriteLong(long value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteLong(value, array, startIndex);
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xABABABAB, new byte[] { 0, 0xAB, 0xAB, 0xAB, 0xAB, 0, 0, 0, 0 }, 1)] // Write 6 from position 1
  public void WriteULong(long value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteULong((ulong) value, array, startIndex);
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(11223344.0, new byte[] { 0, 0, 0, 0, 0, 0x26, 0x68, 0x65, 0x41 }, 1)] // Write 6 from position 1
  public void WriteDouble(double value, byte[] expectedArray, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    Writers.WriteDouble(value, array, startIndex);
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }
}