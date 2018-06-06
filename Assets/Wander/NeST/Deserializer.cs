using System;

namespace Wander.NeST
{
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

    public T Deserialize<T>() where T : ISerializable, new()
    {
      T t = new T();
      t.DeserializeFrom(this);
      return t;
    }

    public T DeserializeUsing<T>(Readers.Reader<T> reader)
    {
      T value;
      readHead += reader(out value, data, readHead);
      return value;
    }
  }
}