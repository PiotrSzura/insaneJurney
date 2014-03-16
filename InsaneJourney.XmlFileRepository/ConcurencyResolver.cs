
using System.Collections.Generic;
using InsaneJourney.Calculator.Model;
using InsaneJourney.XmlFileRepository.DeserializationModel;
using InsaneJourney.XmlFileRepository.Interfaces;
using Vehicle = InsaneJourney.Calculator.Model.Vehicle;

namespace InsaneJourney.XmlFileRepository
{
    internal class ConcurencyResolver : IConcurencyResolver
    {
        public List<Vehicle> GetConcurrentResult(Garage xmlGarage)
        {
            var typeNameConsumptionKeySet = new HashSet<string>();
            var typeNameKeySet = new HashSet<string>();
            var result = new List<Vehicle>();

            foreach (var xmlVehicle in xmlGarage.Vehicles)
            {
                var vehicleKey = xmlVehicle.Type + xmlVehicle.Name;
                if (!typeNameKeySet.Contains(vehicleKey))
                {
                    var vehicle = new Vehicle
                    {
                        Name = xmlVehicle.Name,
                        Type = xmlVehicle.Type,
                        NumberOfSeats = xmlVehicle.Seats,
                        FuelConsumptions = new List<FuelConsumption>()
                    };

                    foreach (var xmlFuelConsumption in xmlVehicle.FuelConsumptions)
                    {
                        var consumptionkey = vehicleKey + xmlFuelConsumption.Name;
                        if (!typeNameConsumptionKeySet.Contains(consumptionkey))
                        {
                            vehicle.FuelConsumptions.Add(new FuelConsumption
                            {
                                Name = xmlFuelConsumption.Name,
                                Value = xmlFuelConsumption.Value
                            });
                            typeNameConsumptionKeySet.Add(consumptionkey);
                        }
                    }
                    result.Add(vehicle);
                    typeNameKeySet.Add(vehicleKey);
                }
            }
            return result;
        }
    }
}
