using System.Collections.Generic;
using System.Linq;

namespace InsaneJourney.Calculator.Model
{
    public class CalculationResponse
    {
        public IList<CalculationSet> AllCalculationResults { get; set; }

        public IEnumerable<CalculationSet> AllCalculationResultsSortedByPrice
        {
            get
            {
                if (AllCalculationResults != null && AllCalculationResults.Any())
                    return AllCalculationResults.OrderBy(c => c.Calculations.Min(d => d.TotalFuelConsumption));
                return new List<CalculationSet>();
            }
        }

        public CalculationSet CheapestTrip
        {
            get
            {
                var result = AllCalculationResultsSortedByPrice.ToList().FirstOrDefault();
                if (result != null)
                {
                    var sortSingleResult = new CalculationSet()
                        {
                            Calculations =
                                result.Calculations.OrderBy(d => d.TotalFuelConsumption).Select(
                                    c =>
                                    new Calculation
                                        {
                                            VehicleType = c.VehicleType,
                                            FuelcConsumptionOption = c.FuelcConsumptionOption,
                                            RequiredVechicles = c.RequiredVechicles,
                                            VehicleName = c.VehicleName,
                                            TotalFuelConsumption = c.TotalFuelConsumption
                                        }).ToList()
                        };
                    return sortSingleResult;
                }
                return null;
            }
        }
        public string Message { get; set; }
    }
}
