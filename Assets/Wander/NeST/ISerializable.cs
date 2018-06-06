namespace Wander.NeST
{
  public interface ISerializable
  {
    int SerializeTo(byte[] array, int index = 0);
    int DeserializeFrom(byte[] array, int index = 0);
  }
}