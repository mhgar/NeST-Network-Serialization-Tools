namespace Wander.NeST
{
  /// <summary>
  /// Class containing methods that will read primitive values from an array
  /// of bytes at a specified index. Functions return the number of bytes
  /// read, so if these fail they'll return 0.
  /// </summary>
  public static class Readers
  {
    public delegate T Reader<T>(out T value, byte[] array, int index = 0);

    public static int ReadByte(out byte value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = 0; return 0; }

      value = array[index];
      return 1;
    }

    public static int ReadSByte(out sbyte value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = 0; return 0; }

      value = (sbyte)array[index];
      return 1;
    }

    public static unsafe int ReadShort(out short value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = 0; return 0; }

      short output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.ShortLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.ShortLength;
    }

    public static unsafe int ReadUShort(out ushort value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = 0; return 0; }

      ushort output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.UShortLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.UShortLength;
    }

    public static unsafe int ReadChar(out char value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = '\0'; return 0; }

      char output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.CharLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.CharLength;
    }

    public static unsafe int ReadInt(out int value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = 0; return 0; }

      int output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.IntLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.IntLength;
    }

    public static unsafe int ReadUInt(out uint value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = 0; return 0; }

      uint output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.UIntLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.UIntLength;
    }

    public static unsafe int ReadFloat(out float value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = 0; return 0; }

      float output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.FloatLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.FloatLength;
    }

    public static unsafe int ReadLong(out long value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = 0; return 0; }

      long output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.LongLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.LongLength;
    }

    public static unsafe int ReadULong(out ulong value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = 0; return 0; }

      ulong output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.ULongLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.ULongLength;
    }

    public static unsafe int ReadDouble(out double value, byte[] array, int index = 0)
    {
      if (index + 1 > array.Length) { value = 0; return 0; }

      double output;
      byte* ptr = (byte*)&output;
      for (int i = 0; i < Sizes.DoubleLength; i++) ptr[i] = array[index + i];
      value = output;
      return Sizes.DoubleLength;
    }
  }
}
