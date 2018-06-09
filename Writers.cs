using System;

namespace Wander.NeST
{
  /// <summary>
  /// Class containing methods that will write primitive values to an array
  /// of bytes at a specified index. Functions return the number of bytes
  /// written, so if these fail they'll return 0.
  /// </summary>
  public static class Writers
  {
    public delegate void Writer<T>(T value, ByteArray array);

    public static void WriteString(string value, ByteArray array)
    {
      var length = value.Length;
      var numBytes = 4 + length * 2;
      if (!array.Has(numBytes)) throw new ArgumentOutOfRangeException();

      WriteInt(length, array);
      foreach(var c in value) WriteChar(c, array);
    }

    public static void WriteByte(byte value, ByteArray array)
    {
      if (!array.HasNext()) throw new ArgumentOutOfRangeException();
      array.Write(value);
    }

    public static void WriteBool(bool value, ByteArray array)
    {
      if (!array.HasNext()) throw new ArgumentOutOfRangeException();
      array.Write((value ? (byte) 1 : (byte) 0));
    }

    public static void WriteSByte(sbyte value, ByteArray array)
    {
      if (!array.HasNext()) throw new ArgumentOutOfRangeException();
      array.Write((byte) value);
    }

    public static unsafe void WriteShort(short value, ByteArray array)
    {
      if (!array.Has(2)) throw new ArgumentOutOfRangeException();
      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.ShortLength; i++) array.Write(ptr[i]);
    }

    public static unsafe void WriteUShort(ushort value, ByteArray array)
    {
      if (!array.Has(2)) throw new ArgumentOutOfRangeException();
      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.UShortLength; i++) array.Write(ptr[i]);
    }

    public static unsafe void WriteChar(char value, ByteArray array)
    {
      if (!array.Has(2)) throw new ArgumentOutOfRangeException();
      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.CharLength; i++) array.Write(ptr[i]);
    }

    public static unsafe void WriteInt(int value, ByteArray array)
    {
      if (!array.Has(Sizes.IntLength)) throw new ArgumentOutOfRangeException();
      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.IntLength; i++) array.Write(ptr[i]);
    }

    public static unsafe void WriteUInt(uint value, ByteArray array)
    {
      if (!array.Has(Sizes.UIntLength)) throw new ArgumentOutOfRangeException();
      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.UIntLength; i++) array.Write(ptr[i]);
    }

    public static unsafe void WriteFloat(float value, ByteArray array)
    {
      if (!array.Has(Sizes.FloatLength)) throw new ArgumentOutOfRangeException();
      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.FloatLength; i++) array.Write(ptr[i]);
    }

    public static unsafe void WriteDouble(double value, ByteArray array)
    {
      if (!array.Has(Sizes.DoubleLength)) throw new ArgumentOutOfRangeException();
      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.DoubleLength; i++) array.Write(ptr[i]);
    }

    public static unsafe void WriteLong(long value, ByteArray array)
    {
      if (!array.Has(Sizes.LongLength)) throw new ArgumentOutOfRangeException();
      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.LongLength; i++) array.Write(ptr[i]);
    }

    public static unsafe void WriteULong(ulong value, ByteArray array)
    {
      if (!array.Has(Sizes.ULongLength)) throw new ArgumentOutOfRangeException();
      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.ULongLength; i++) array.Write(ptr[i]);
    }
  }
}