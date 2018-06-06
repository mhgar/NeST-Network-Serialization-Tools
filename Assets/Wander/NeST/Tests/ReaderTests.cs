using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

using Wander.NeST;

public class ReadersTests 
{
    [TestCase(new byte[] { 1, 6 }, 6, 1, 1)] // Read 6 from position 1
    [TestCase(new byte[] { }, 0, 0, 1)] // Read nothing from out of bounds
    public void ReadByte(byte[] array, byte expectedValue, int expectedRead, int startIndex = 0)
    {
        byte value;
        var read = Readers.ReadByte(out value, array, startIndex);

        Assert.AreEqual(read, expectedRead, "Read wrong number of bytes");
        Assert.AreEqual(value, expectedValue, "Read wrong value: " + value + " != " + expectedValue);
    }

    [TestCase(new byte[] { 1, 6 }, 6, 1, 1)] // Read 6 from position 1
    [TestCase(new byte[] { }, 0, 0, 1)] // Read nothing from out of bounds
    public void ReadSByte(byte[] array, sbyte expectedValue, int expectedRead, int startIndex = 0)
    {
        sbyte value;
        var read = Readers.ReadSByte(out value, array, startIndex);

        Assert.AreEqual(read, expectedRead, "Read wrong number of bytes");
        Assert.AreEqual(value, expectedValue, "Read wrong value: " + value + " != " + expectedValue);
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0x00 }, 0x00AB, 2, 1)]
    [TestCase(new byte[] { }, 0, 0, 1)] // Read nothing from out of bounds
    public void ReadShort(byte[] array, long expectedValue, int expectedRead, int startIndex = 0)
    {
        short value;
        var read = Readers.ReadShort(out value, array, startIndex);

        Assert.AreEqual(read, expectedRead, "Read wrong number of bytes");
        Assert.AreEqual(value, expectedValue, "Read wrong value: " + value + " != " + expectedValue);
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0x00 }, 0x00AB, 2, 1)]
    [TestCase(new byte[] { }, 0, 0, 1)] // Read nothing from out of bounds
    public void ReadUShort(byte[] array, long expectedValue, int expectedRead, int startIndex = 0)
    {
        ushort value;
        var read = Readers.ReadUShort(out value, array, startIndex);

        Assert.AreEqual(read, expectedRead, "Read wrong number of bytes");
        Assert.AreEqual(value, expectedValue, "Read wrong value: " + value + " != " + expectedValue);
    }

    [TestCase(new byte[] { 0x00, (byte) 'a', 0x00 }, (long) 'a', 2, 1)]
    [TestCase(new byte[] { }, 0, 0, 1)] // Read nothing from out of bounds
    public void ReadChar(byte[] array, long expectedValue, int expectedRead, int startIndex = 0)
    {
        char value;
        var read = Readers.ReadChar(out value, array, startIndex);

        Assert.AreEqual(read, expectedRead, "Read wrong number of bytes");
        Assert.AreEqual(value, expectedValue, "Read wrong value: " + value + " != " + expectedValue);
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0xAB, 0x00, 0x00 }, 0x0000ABAB, 4, 1)]
    [TestCase(new byte[] { }, 0, 0, 1)] // Read nothing from out of bounds
    public void ReadInt(byte[] array, long expectedValue, int expectedRead, int startIndex = 0)
    {
        int value;
        var read = Readers.ReadInt(out value, array, startIndex);

        Assert.AreEqual(read, expectedRead, "Read wrong number of bytes");
        Assert.AreEqual(value, expectedValue, "Read wrong value: " + value + " != " + expectedValue);
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0xAB, 0x00, 0x00 }, 0x0000ABAB, 4, 1)]
    [TestCase(new byte[] { }, 0, 0, 1)] // Read nothing from out of bounds
    public void ReadUInt(byte[] array, long expectedValue, int expectedRead, int startIndex = 0)
    {
        uint value;
        var read = Readers.ReadUInt(out value, array, startIndex);

        Assert.AreEqual(read, expectedRead, "Read wrong number of bytes");
        Assert.AreEqual(value, expectedValue, "Read wrong value: " + value + " != " + expectedValue);
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0xAB, 0xAB, 0xAB, 0x00, 0x00, 0x00, 0x00 }, 0x00000000ABABABAB, 8, 1)]
    [TestCase(new byte[] { }, 0, 0, 1)] // Read nothing from out of bounds
    public void ReadLong(byte[] array, long expectedValue, int expectedRead, int startIndex = 0)
    {
        long value;
        var read = Readers.ReadLong(out value, array, startIndex);

        Assert.AreEqual(read, expectedRead, "Read wrong number of bytes");
        Assert.AreEqual(value, expectedValue, "Read wrong value: " + value + " != " + expectedValue);
    }

    [TestCase(new byte[] { 0x00, 0xAB, 0xAB, 0xAB, 0xAB, 0x00, 0x00, 0x00, 0x00 }, 0x00000000ABABABAB, 8, 1)]
    [TestCase(new byte[] { }, 0, 0, 1)] // Read nothing from out of bounds
    public void ReadULong(byte[] array, long expectedValue, int expectedRead, int startIndex = 0)
    {
        ulong value;
        var read = Readers.ReadULong(out value, array, startIndex);

        Assert.AreEqual(read, expectedRead, "Read wrong number of bytes");
        Assert.AreEqual(value, expectedValue, "Read wrong value: " + value + " != " + expectedValue);
    }
}
