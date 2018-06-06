namespace Wander.NeST
{
  public class Deserializer
  {
    byte[] data;
    int readHead = 0;

    public Deserializer(byte[] array, int index = 0)
    {
      data = array;
      readHead = index;
    }

    public T Deserialize<T>() where T : ISerializable, new()
    {
      T t = new T();
      int written = t.DeserializeFrom(data, readHead);
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