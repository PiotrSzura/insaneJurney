using System.Collections.Generic;
using System.Linq;
using InsaneJourney.Calculator.Calculation.CalculationRules;
using InsaneJourney.Calculator.Model;

namespace InsaneJourney.Calculator.Calculation
{
    internal class FuelConsumptionCalculationModel : ICalculationModel
    {
        public CalculationRequest CalculationRequest { set; get; }
        public List<ICalculationRule> CalculationRules { set; get; }
        public IRequiredVehiclesRule RequiredVehiclesRule { set; get; }

        public CalculationResponse Calculate(ICalculatorRepository repository)
        {

            var calculationResponse = new CalculationResponse {AllCalculationResults = new List<CalculationSet>()};
            var vehicleData = repository.GetVehicles().ToList();
            if (CanPerformCalculation(vehicleData))
            {
                foreach (var vehicle in vehicleData)
                {
                    var calculationSet = new CalculationSet{Calculations = new List<Model.Calculation>()};

                    
                    foreach (var consumption in vehicle.FuelConsumptions)
                    {
                        var vehiclesRequired =
                            RequiredVehiclesRule.GetNublerOfRequiredVechicles(CalculationRequest.Attendees,         
                            vehicle.NumberOfSeats);

                        foreach (var calculationRule in CalculationRules)
                        {
                            calculationSet.Calculations.Add(new Model.Calculation
                            {
                                RequiredVechicles = vehiclesRequired,
                                TotalFuelConsumption =
                                    calculationRule.PerformCalculation(vehiclesRequired, consumption,
                                                                       CalculationRequest.TripLength),
                                                                    FuelcConsumptionOption = consumption.Name,
                                                                    VehicleName = vehicle.Name,
                                                                    VehicleType = vehicle.Type

                            });
                        }
                    }
                    calculationResponse.AllCalculationResults.Add(calculationSet);
                }
                calculationResponse.Message = "Calculation succesfull";
            }
            return calculationResponse;
        }

        private bool CanPerformCalculation(IEnumerable<Vehicle> vehicles)
        {
            return CalculationRequest != null && CalculationRules != null && RequiredVehiclesRule != null &&
                   CalculationRules.Any() && vehicles.Any();
        }
    }
}
