using System.Collections.Generic;
using InsaneJourney.Calculator.Calculation;
using InsaneJourney.Calculator.Calculation.CalculationRules;
using InsaneJourney.Calculator.Model;

namespace InsaneJourney.Calculator
{
    public class CalculatorFactory
    {
        public ICalculationModel GetCalculator (CalculationRequest request)
        {
            if (request.Attendees == 1)
                return new OtherProviderCalculationModel();

            return new FuelConsumptionCalculationModel
                {
                    CalculationRules = new List<ICalculationRule>
                        {
                            new FuelConsumptionCalculationRule()
                        },
                        RequiredVehiclesRule = new DriversIncludedRequiredVehicleRule(),
                    CalculationRequest = request
                };

        }
    }
}
