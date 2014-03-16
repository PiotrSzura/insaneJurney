using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace InsaneJourney.XmlFileRepository.DeserializationModel
{
    [Serializable]
    [XmlType(AnonymousType = true, TypeName = "garage")]
    [XmlRoot(IsNullable = false)]
    public class Garage
    {
        [XmlArray("vehicles", IsNullable = false)]
        public List<Vehicle> Vehicles { get; set; }

    }
}
