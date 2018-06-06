using System;

namespace Wander.NeST
{
  public class Serializer
  {
    byte[] data;
    int writeHead = 0;
    int dataLength;

    public Serializer(byte[] array, int startIndex = 0, int length = -1)
    {
      if (array == null) 
        throw new ArgumentNullException("array");

      if (length > array.Length) 
        throw new ArgumentOutOfRangeException("length");

      if (startIndex > length - 1) 
        throw new ArgumentOutOfRangeException("startIndex");

      writeHead = startIndex;
      data = array;

      // If length is default value, use size of the array instead.
      dataLength = (length < 0 ? data.Length : length);
    }
    // Don't need new() here; just for parity with Deserialize()
    public void Serialize<T>(T structure) where T : ISerializable, new()
    {
      structure.SerializeTo(this);
    }

    public void SerializeUsing<T>(T value, Writers.Writer<T> writer)
    {
      // Allow thrown exceptions to fall through into the caller.
      writeHead += writer(value, data, writeHead);
    }
  }
}