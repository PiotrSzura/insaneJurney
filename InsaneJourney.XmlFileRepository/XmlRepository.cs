using System;
using System.Collections.Generic;
using System.Configuration;
using InsaneJourney.Calculator;
using InsaneJourney.XmlFileRepository.DeserializationModel;
using InsaneJourney.XmlFileRepository.Interfaces;
using Vehicle = InsaneJourney.Calculator.Model.Vehicle;

namespace InsaneJourney.XmlFileRepository
{
    public class XmlRepository :  ICalculatorRepository
    {
        private readonly IConcurencyResolver _concurencyResolver;
        private readonly IDeserializer<Garage> _deserializer;
        

        public XmlRepository()
        {
            _concurencyResolver = new ConcurencyResolver();
            _deserializer = new Deserializer<Garage>(typeof(Garage).Name.ToLower(), XmlFileRepositoryConfigSection.SchemaPath, XmlFileRepositoryConfigSection.XmlDataPath);
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            try
            {
                var garage = _deserializer.Deserialize();
                return _concurencyResolver.GetConcurrentResult(garage);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
