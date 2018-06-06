using System;

namespace Wander.NeST
{
  /// A deserialization helper that given a byte array allows you to deserialize
  /// objects from it until the end of the array.
  public class Deserializer
  {
    public byte[] Array { get { return data; } }
    public int Length { get { return dataLength; } }
    public int Position
    {
      get { return readHead; }
      set
      {
        if (value >= dataLength)
          throw new IndexOutOfRangeException();
        else
          readHead = value;
      }
    }

    byte[] data;
    int readHead = 0;
    int dataLength;

    public Deserializer(byte[] array, int startIndex = 0, int length = -1)
    {
      if (array == null) 
        throw new ArgumentNullException("array");

      if (length > array.Length) 
        throw new ArgumentOutOfRangeException("length");

      // If length is default value, use size of the array instead.
      dataLength = (length < 0 ? array.Length : length);

      // Check if start index is greater than the array length, or if 'length'
      // has been set, check against that instead.
      if (startIndex > dataLength - 1) 
        throw new ArgumentOutOfRangeException("startIndex");

      data = array;
      readHead = startIndex;      
    }

    /// Deserialize an ISerializable from this object's internal byte array.
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