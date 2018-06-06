using System;

namespace Wander.NeST
{
  /// A serialization helper that given a byte array allows you to serialize
  /// objects from it until the end of the array.
  public class Serializer
  {
    public byte[] Array { get { return data; }}

    byte[] data;
    int writeHead = 0;
    int dataLength;

    public Serializer(byte[] array, int startIndex = 0, int length = -1)
    {
      if (array == null) 
        throw new ArgumentNullException("array");

      if (length > array.Length) 
        throw new ArgumentOutOfRangeException("length");

      // Check if start index is greater than the array length, or if 'length'
      // has been set, check against that instead.
      if (startIndex > (length < 0 ? array.Length : length) - 1) 
        throw new ArgumentOutOfRangeException("startIndex");

      writeHead = startIndex;
      data = array;

      // If length is default value, use size of the array instead.
      dataLength = (length < 0 ? data.Length : length);
    }

    // Don't need new() here; just for parity with Deserialize()
    /// Serialize an ISerializable to this object's internal byte array.
    public void Serialize<T>(T structure) where T : ISerializable, new()
    {
      structure.SerializeTo(this);
    }

    /// Serialize an object using a writer function that implements how the
    /// object should be serialized.
    public void SerializeUsing<T>(T value, Writers.Writer<T> writer)
    {
      // Allow thrown exceptions to fall through into the caller.
      writeHead += writer(value, data, writeHead);
    }
  }
}