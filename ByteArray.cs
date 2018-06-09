using System;

namespace Wander.NeST
{
  public class ByteArray
  {
    public byte[] Array { get { return buffer;} }
    public int Count { get; private set; }
    public int Position { 
      get { return position; } 
    }

    int position = 0;
    byte[] buffer;

    public ByteArray(byte[] array, int startIndex, int count)
    {
      if (array == null)
        throw new ArgumentNullException("array");

      if (count > array.Length)
        throw new ArgumentOutOfRangeException("length");

      // If length is default value, use size of the array instead.
      Count = (count < 0 ? array.Length : count);

      // Check if start index is greater than the array length, or if 'length'
      // has been set, check against that instead.
      if (startIndex > Count - 1)
        throw new ArgumentOutOfRangeException("startIndex");

      buffer = array;
      position = startIndex;
    }  

    public ByteArray(byte[] array, int startIndex) 
      : this(array, startIndex, array.Length) 
    {
    }

    public ByteArray(byte[] array)
      : this(array, 0)
    {
    }

    public ByteArray(int count)
    {
      position = 0;
      buffer = new byte[count];
      Count = count;
    }

    public bool HasNext()
    {
      return position < Count;
    }

    public bool Has(int count)
    {
      return position + count <= Count;
    }

    public void Increment(int count)
    {
      if (!Has(count))
        throw new IndexOutOfRangeException(
          String.Format("Position={0} Increment={1} Length={2}", position, count, Count)
        );
      else
        position += count;
    }
  }
}
