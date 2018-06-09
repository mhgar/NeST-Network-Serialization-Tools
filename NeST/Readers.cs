using System;

namespace Wander.NeST
{
  /// <summary>
  /// Class containing methods that will read primitive values from an array
  /// of bytes at a specified index. Functions return the number of bytes
  /// read, so if these fail they'll return 0.
  /// </summary>
  public static class Readers
  {
    public delegate int Reader<T>(out T value, byte[] array, int index = 0);

    public static int ReadString(out string value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      int length;
      ReadInt(out length, array, index);
      value = System.Text.Encoding.Default.GetString(array, index + 4, length);

      return 4 + length * 2;
    }

    public static int ReadByte(out byte value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      value = array[index];
      return 1;
    }

    public static int ReadSByte(out sbyte value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      value = (sbyte)array[index];
      return 1;
    }

    public static unsafe int ReadShort(out short value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      short output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.ShortLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.ShortLength;
    }

    public static unsafe int ReadUShort(out ushort value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      ushort output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.UShortLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.UShortLength;
    }

    public static unsafe int ReadChar(out char value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      char output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.CharLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.CharLength;
    }

    public static unsafe int ReadInt(out int value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      int output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.IntLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.IntLength;
    }

    public static unsafe int ReadUInt(out uint value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      uint output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.UIntLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.UIntLength;
    }

    public static unsafe int ReadFloat(out float value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      float output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.FloatLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.FloatLength;
    }

    public static unsafe int ReadLong(out long value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      long output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.LongLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.LongLength;
    }

    public static unsafe int ReadULong(out ulong value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      ulong output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.ULongLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.ULongLength;
    }

    public static unsafe int ReadDouble(out double value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) throw new IndexOutOfRangeException();

      double output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.DoubleLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.DoubleLength;
    }
  }
}
