using System.Collections.Generic;
using InsaneJourney.Calculator.Model;

namespace InsaneJourney.Calculator
{
    public interface ICalculatorRepository
    {
        IEnumerable<Vehicle> GetVehicles();
    }
}
