namespace InsaneJourney.XmlFileRepository.Interfaces
{
    interface IDeserializer<out T>
    {
         T Deserialize();
    }
}
