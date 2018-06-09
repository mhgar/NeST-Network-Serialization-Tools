using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

using Wander.NeST;

public class ReadersTests 
{
    [TestCase(new byte[] { 1, 6 }, 6, 1)] // Read 6 from position 1
    public void ReadByte(byte[] array, byte expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadByte(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }

    [TestCase(new byte[] { 1, 6 }, 6, 1)] // Read 6 from position 1
    public void ReadSByte(byte[] array, sbyte expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadSByte(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0x00 }, 0x00AB, 1)]
    public void ReadShort(byte[] array, long expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadShort(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0x00 }, 0x00AB, 1)]

    public void ReadUShort(byte[] array, long expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadUShort(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }

    [TestCase(new byte[] { 0x00, (byte) 'a', 0x00 }, (long) 'a', 1)]

    public void ReadChar(byte[] array, long expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadChar(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0xAB, 0x00, 0x00 }, 0x0000ABAB, 1)]

    public void ReadInt(byte[] array, long expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadInt(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0xAB, 0x00, 0x00 }, 0x0000ABAB, 1)]

    public void ReadUInt(byte[] array, long expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadUInt(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0xAB, 0xAB, 0xAB, 0x00, 0x00, 0x00, 0x00 }, 0x00000000ABABABAB, 1)]

    public void ReadLong(byte[] array, long expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadLong(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0xAB, 0xAB, 0xAB, 0x00, 0x00, 0x00, 0x00 }, 0x00000000ABABABAB, 1)]

    public void ReadULong(byte[] array, long expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadULong(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }

    [TestCase(new byte[] { 0x00, 0x00, 0xC0, 0x7F, 0x44, 0x00, 0x00, 0x00, 0x00 }, 1023f, 1)]

    public void ReadFloat(byte[] array, float expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadFloat(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }

    [TestCase(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x26, 0x68, 0x65, 0x41 }, 11223344.0, 1)]

    public void ReadDouble(byte[] array, double expectedValue, int startIndex = 0)
    {
        var value = Readers.ReadDouble(new ByteArray(array, startIndex));
        Assert.AreEqual(expectedValue, value, "Read wrong value");
    }
}
