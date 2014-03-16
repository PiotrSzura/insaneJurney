using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace InsaneJourney.XmlFileRepository.DeserializationModel
{
    [Serializable]
    [XmlType(TypeName = "vehicle")]
    public class Vehicle
    {
        [XmlArray("fuelConsumptions", IsNullable = false)]
        public List<Consumption> FuelConsumptions { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("seats")]
        public ushort Seats { get; set; }
    }
}
