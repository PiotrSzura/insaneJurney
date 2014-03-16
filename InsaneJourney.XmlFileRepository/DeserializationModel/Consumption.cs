using System;
using System.Xml.Serialization;

namespace InsaneJourney.XmlFileRepository.DeserializationModel
{
    [Serializable]
    [XmlType(TypeName = "fuelConsumption")]
    public class Consumption
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlTextAttribute]
        public decimal Value { get; set; }
    }
}
