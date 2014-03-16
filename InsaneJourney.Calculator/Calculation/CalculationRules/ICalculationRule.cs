using InsaneJourney.Calculator.Model;

namespace InsaneJourney.Calculator.Calculation.CalculationRules
{
    public interface ICalculationRule
    {
        string CalculationName { get; }
        decimal PerformCalculation(int vehicleRequired, FuelConsumption fuelConsumption, decimal distance);
    }
}
