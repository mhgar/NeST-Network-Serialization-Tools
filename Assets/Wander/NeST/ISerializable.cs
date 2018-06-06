namespace Wander.NeST
{
  public interface ISerializable
  {
    void SerializeTo(Serializer serializer);
    void DeserializeFrom(Deserializer derserializer);
  }
}