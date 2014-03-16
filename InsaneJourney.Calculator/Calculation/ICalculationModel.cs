using System.Collections.Generic;
using InsaneJourney.Calculator.Calculation.CalculationRules;
using InsaneJourney.Calculator.Model;

namespace InsaneJourney.Calculator.Calculation
{
    public interface ICalculationModel
    {
         CalculationRequest CalculationRequest { set; get; }
        List<ICalculationRule> CalculationRules { get; set; }
        IRequiredVehiclesRule RequiredVehiclesRule { set; get; }
        CalculationResponse Calculate(ICalculatorRepository repository);

    }
}
