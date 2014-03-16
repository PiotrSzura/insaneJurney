using System.Collections.Generic;
using InsaneJourney.XmlFileRepository.DeserializationModel;
using Vehicle = InsaneJourney.Calculator.Model.Vehicle;

namespace InsaneJourney.XmlFileRepository.Interfaces
{
    interface IConcurencyResolver
    {
         List<Vehicle> GetConcurrentResult(Garage xmlGarage);
    }
}
