using System.Collections.Generic;
using InsaneJourney.Calculator.Calculation.CalculationRules;
using InsaneJourney.Calculator.Model;

namespace InsaneJourney.Calculator.Calculation
{
    internal class OtherProviderCalculationModel : ICalculationModel
    {
        public CalculationRequest CalculationRequest { get; set; }
        public List<ICalculationRule> CalculationRules { get; set; }
        public IRequiredVehiclesRule RequiredVehiclesRule { get; set; }

        public CalculationResponse Calculate(ICalculatorRepository repository)
        {
            return new CalculationResponse {Message = "Choose alternative transport"};
        }
    }
}
