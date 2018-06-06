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

  [TestCase(6, new byte[] { 0, 6, 0, 0, 0, 0, 0, 0, 0 }, 1, 1)] // Write 6 from position 1
  [TestCase(0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 128)] // Write nothing from of bounds
  public void WriteByte(byte value, byte[] expectedArray, int expectedWrite, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    var Write = Writers.WriteByte(value, array, startIndex);

    Assert.AreEqual(Write, expectedWrite, "Write wrong number of bytes");

    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(6, new byte[] { 0, 6, 0, 0, 0, 0, 0, 0, 0 }, 1, 1)] // Write 6 from position 1
  [TestCase(0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 128)] // Write nothing from of bounds
  public void WriteSByte(sbyte value, byte[] expectedArray, int expectedWrite, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    var Write = Writers.WriteSByte(value, array, startIndex);

    Assert.AreEqual(Write, expectedWrite, "Write wrong number of bytes");
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase('a', new byte[] { 0, (byte) 'a', 0, 0, 0, 0, 0, 0, 0 }, 2, 1)] // Write 6 from position 1
  [TestCase('\0', new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 128)] // Write nothing from of bounds
  public void WriteChar(char value, byte[] expectedArray, int expectedWrite, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    var Write = Writers.WriteChar(value, array, startIndex);

    Assert.AreEqual(Write, expectedWrite, "Write wrong number of bytes");
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xAB, new byte[] { 0, 0xAB, 0, 0, 0, 0, 0, 0, 0 }, 2, 1)] // Write 6 from position 1
  [TestCase(0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 128)] // Write nothing from of bounds
  public void WriteShort(long value, byte[] expectedArray, int expectedWrite, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    var Write = Writers.WriteShort((short) value, array, startIndex);

    Assert.AreEqual(Write, expectedWrite, "Write wrong number of bytes");
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xAB, new byte[] { 0, 0xAB, 0, 0, 0, 0, 0, 0, 0 }, 2, 1)] // Write 6 from position 1
  [TestCase(0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 128)] // Write nothing from of bounds
  public void WriteUShort(long value, byte[] expectedArray, int expectedWrite, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    var Write = Writers.WriteUShort((ushort) value, array, startIndex);

    Assert.AreEqual(Write, expectedWrite, "Write wrong number of bytes");
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xABAB, new byte[] { 0, 0xAB, 0xAB, 0, 0, 0, 0, 0, 0 }, 4, 1)] // Write 6 from position 1
  [TestCase(0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 128)] // Write nothing from of bounds
  public void WriteInt(long value, byte[] expectedArray, int expectedWrite, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    var Write = Writers.WriteInt((int) value, array, startIndex);

    Assert.AreEqual(Write, expectedWrite, "Write wrong number of bytes");
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xABAB, new byte[] { 0, 0xAB, 0xAB, 0, 0, 0, 0, 0, 0 }, 4, 1)] // Write 6 from position 1
  [TestCase(0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 128)] // Write nothing from of bounds
  public void WriteUInt(long value, byte[] expectedArray, int expectedWrite, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    var Write = Writers.WriteUInt((uint) value, array, startIndex);

    Assert.AreEqual(Write, expectedWrite, "Write wrong number of bytes");
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xABABABAB, new byte[] { 0, 0xAB, 0xAB, 0xAB, 0xAB, 0, 0, 0, 0 }, 8, 1)] // Write 6 from position 1
  [TestCase(0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 128)] // Write nothing from of bounds
  public void WriteLong(long value, byte[] expectedArray, int expectedWrite, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    var Write = Writers.WriteLong(value, array, startIndex);

    Assert.AreEqual(Write, expectedWrite, "Write wrong number of bytes");
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }

  [TestCase(0xABABABAB, new byte[] { 0, 0xAB, 0xAB, 0xAB, 0xAB, 0, 0, 0, 0 }, 8, 1)] // Write 6 from position 1
  [TestCase(0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 128)] // Write nothing from of bounds
  public void WriteULong(long value, byte[] expectedArray, int expectedWrite, int startIndex = 0)
  {
    var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    var Write = Writers.WriteULong((ulong) value, array, startIndex);

    Assert.AreEqual(Write, expectedWrite, "Write wrong number of bytes");
    Assert.IsTrue(CompareArray(array, expectedArray), "Array did not match expected array.");
  }
}