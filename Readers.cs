using System;
using System.Text;

namespace Wander.NeST
{
  /// <summary>
  /// Class containing methods that will read primitive values from an array
  /// of bytes at a specified index. Functions return the number of bytes
  /// read, so if these fail they'll return 0.
  /// </summary>
  public static class Readers
  {
    public delegate T Reader<T>(ByteArray array);

    public static string ReadString(ByteArray array)
    {
      if (!array.Has(Sizes.IntLength)) throw new IndexOutOfRangeException();

      var length = ReadInt(array);

      if (!array.Has(length)) throw new IndexOutOfRangeException();

      var str = new StringBuilder();
      for (int i = 0; i < length; i++) str.Append(ReadChar(array));
      return str.ToString();
    }

    public static byte ReadByte(ByteArray array)
    {
      if (!array.HasNext()) throw new IndexOutOfRangeException();
      return array.Read();
    }

    public static sbyte ReadSByte(ByteArray array)
    {
      if (!array.HasNext()) throw new IndexOutOfRangeException();
      return (sbyte) array.Read();
    }

    public static unsafe short ReadShort(ByteArray array)
    {
      if (!array.Has(Sizes.ShortLength)) throw new IndexOutOfRangeException();

      short output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.ShortLength; i++) ptr[i] = array.Read();
      return output;
    }
    
    public static unsafe ushort ReadUShort(ByteArray array)
    {
      if (!array.Has(Sizes.UShortLength)) throw new IndexOutOfRangeException();

      ushort output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.UShortLength; i++) ptr[i] = array.Read();
      return output;
    }

    public static unsafe char ReadChar(ByteArray array)
    {
      if (!array.Has(Sizes.CharLength)) throw new IndexOutOfRangeException();

      char output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.CharLength; i++) ptr[i] = array.Read();
      return output;
    }

    public static unsafe int ReadInt(ByteArray array)
    {
      if (!array.Has(Sizes.IntLength)) throw new IndexOutOfRangeException();

      int output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.IntLength; i++) ptr[i] = array.Read();
      return output;
    }

    public static unsafe uint ReadUInt(ByteArray array)
    {
      if (!array.Has(Sizes.UIntLength)) throw new IndexOutOfRangeException();

      uint output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.UIntLength; i++) ptr[i] = array.Read();
      return output;
    }

    public static unsafe float ReadFloat(ByteArray array)
    {
      if (!array.Has(Sizes.FloatLength)) throw new IndexOutOfRangeException();

      float output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.FloatLength; i++) ptr[i] = array.Read();
      return output;
    }

    public static unsafe long ReadLong(ByteArray array)
    {
      if (!array.Has(Sizes.LongLength)) throw new IndexOutOfRangeException();

      long output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.LongLength; i++) ptr[i] = array.Read();
      return output;
    }

    public static unsafe ulong ReadULong(ByteArray array)
    {
      if (!array.Has(Sizes.ULongLength)) throw new IndexOutOfRangeException();

      ulong output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.ULongLength; i++) ptr[i] = array.Read();
      return output;
    }

    public static unsafe double ReadDouble(ByteArray array)
    {
      if (!array.Has(Sizes.DoubleLength)) throw new IndexOutOfRangeException();

      double output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.DoubleLength; i++) ptr[i] = array.Read();
      return output;
    }
  }
}
