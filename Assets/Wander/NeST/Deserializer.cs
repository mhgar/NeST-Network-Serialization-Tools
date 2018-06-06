using System;

namespace Wander.NeST
{
  /// A deserialization helper that given a byte array allows you to deserialize
  /// objects from it until the end of the array.
  public class Deserializer
  {
    byte[] data;
    int readHead = 0;
    int dataLength;

    public Deserializer(byte[] array, int startIndex = 0, int length = -1)
    {
      if (array == null) 
        throw new ArgumentNullException("array");

      if (length > array.Length) 
        throw new ArgumentOutOfRangeException("length");

      if (startIndex > length - 1) 
        throw new ArgumentOutOfRangeException("startIndex");

      data = array;
      readHead = startIndex;

      // If length is default value, use size of the array instead.
      dataLength = (length < 0 ? data.Length : length);
    }

    /// Deerialize an ISerializable from this object's internal byte array.
    public T Deserialize<T>() where T : ISerializable, new()
    {
      T t = new T();
      t.DeserializeFrom(this);
      return t;
    }

    /// Deserialize an object using a reader function that implements how the
    /// object should be serialized.
    public T DeserializeUsing<T>(Readers.Reader<T> reader)
    {
      T value;
      readHead += reader(out value, data, readHead);
      return value;
    }
  }
}