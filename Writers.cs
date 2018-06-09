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
    public delegate int Writer<T>(T value, byte[] array, int index = 0);

    public static int WriteString(string value, byte[] array, int index = 0)
    {
      var length = value.Length;
      var numBytes = 4 + length * 2;
      if (numBytes > array.Length - 1) 
        throw new IndexOutOfRangeException();

      WriteInt(length, array, index);
      foreach(var c in value) WriteChar(c, array, index + 4);

      return numBytes;
    }

    public static int WriteByte(byte value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) 
        throw new IndexOutOfRangeException();

      array[index] = value;
      return 1;
    }

    public static int WriteBool(bool value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) 
        throw new IndexOutOfRangeException();

      array[index] = (value ? (byte) 1 : (byte) 0);
      return 1;
    }

    public static int WriteSByte(sbyte value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) 
        throw new IndexOutOfRangeException();

      array[index] = (byte) value;
      return 1;
    }

    public static unsafe int WriteShort(short value, byte[] array, int index = 0)
    {
      if (index + Sizes.ShortLength > array.Length) 
        throw new IndexOutOfRangeException();

      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.ShortLength; i++) array[index + i] = ptr[i];
      return Sizes.ShortLength; 
    }

    public static unsafe int WriteUShort(ushort value, byte[] array, int index = 0)
    {
      if (index + Sizes.UShortLength > array.Length) 
        throw new IndexOutOfRangeException();

      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.UShortLength; i++) array[index + i] = ptr[i];
      return Sizes.UShortLength; 
    }

    public static unsafe int WriteChar(char value, byte[] array, int index = 0)
    {
      if (index + Sizes.CharLength > array.Length) 
        throw new IndexOutOfRangeException();

      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.CharLength; i++) array[index + i] = ptr[i];
      return Sizes.CharLength;  
    }

    public static unsafe int WriteInt(int value, byte[] array, int index = 0)
    {
      if (index + Sizes.IntLength > array.Length) 
        throw new IndexOutOfRangeException();

      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.IntLength; i++) array[index + i] = ptr[i];
      return Sizes.IntLength;  
    }

    public static unsafe int WriteUInt(uint value, byte[] array, int index = 0)
    {
      if (index + Sizes.UIntLength > array.Length) 
        throw new IndexOutOfRangeException();

      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.UIntLength; i++) array[index + i] = ptr[i];
      return Sizes.UIntLength;  
    }

    public static unsafe int WriteFloat(float value, byte[] array, int index = 0)
    {
      if (index + Sizes.FloatLength > array.Length) 
        throw new IndexOutOfRangeException();

      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.FloatLength; i++) array[index + i] = ptr[i];
      return Sizes.FloatLength;
    }

    public static unsafe int WriteDouble(double value, byte[] array, int index = 0)
    {
      if (index + Sizes.DoubleLength > array.Length) 
        throw new IndexOutOfRangeException();

      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.DoubleLength; i++) array[index + i] = ptr[i];
      return Sizes.DoubleLength;
    }

    public static unsafe int WriteLong(long value, byte[] array, int index = 0)
    {
      if (index + Sizes.LongLength > array.Length) 
        throw new IndexOutOfRangeException();

      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.LongLength; i++) array[index + i] = ptr[i];
      return Sizes.LongLength;
    }

    public static unsafe int WriteULong(ulong value, byte[] array, int index = 0)
    {
      if (index + Sizes.ULongLength > array.Length) 
        throw new IndexOutOfRangeException();

      byte *ptr = (byte *) &value;
      for (int i = 0; i < Sizes.ULongLength; i++) array[index + i] = ptr[i];
      return Sizes.ULongLength;
    }
  }
}