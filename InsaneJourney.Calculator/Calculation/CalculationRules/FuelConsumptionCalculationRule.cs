using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InsaneJourney.Calculator.Model;

namespace InsaneJourney.Calculator.Calculation.CalculationRules
{
    class FuelConsumptionCalculationRule : ICalculationRule
    {
        public string CalculationName {
            get { return "FuelConsumptionCalculationRule"; }
        }
        public decimal PerformCalculation(int vehicleRequired, FuelConsumption fuelConsumption, decimal distance)
        {
            var vechicles = (decimal) vehicleRequired;
            return (distance) * fuelConsumption.Value * vechicles / 100M;
        }
    }
}
