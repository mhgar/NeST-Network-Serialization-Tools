using System;

namespace Wander.NeST
{
  public class ByteArray
  {
    public byte[] Array { get { return buffer;} }
    public int Count { get; private set; }
    public int Position { 
      get { return position; } 
      set { position = value; }
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
      return Has(1);
    }

    public bool Has(int count)
    {
      return position + count <= Count;
    }

    public void Write(byte value)
    {
      if (HasNext())
        buffer[position++] = value;
      else
        throw new IndexOutOfRangeException();
    }

    public byte Read()
    {
      if (HasNext())
        return buffer[position++];
      else
        throw new IndexOutOfRangeException();
    }

    public void Increment(int count)
    {
      if (!Has(count))
        throw new IndexOutOfRangeException();
      else
        position += count;
    }
  }
}
