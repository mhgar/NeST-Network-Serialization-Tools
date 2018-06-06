namespace Wander.NeST
{
  public class Serializer
  {
    byte[] data;
    int writeHead = 0;

    public Serializer(byte[] array, int startIndex = 0)
    {
      // Throw for errors
      writeHead = startIndex;
      data = array;
    }
    // Don't need new() here; just for parity with Deserialize()
    public void Serialize<T>(T structure) where T : ISerializable, new()
    {
      structure.SerializeTo(this);
    }

    public void SerializeUsing<T>(T value, Writers.Writer<T> writer)
    {
      writeHead += writer(value, data, writeHead);
    }
  }
}