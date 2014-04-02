using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsaneJourney.Calculator.Calculation.CalculationRules
{
    public class DriversIncludedRequiredVehicleRule : IRequiredVehiclesRule
    {
        public int GetNublerOfRequiredVechicles(int attendees, ushort seats)
        {
            if(attendees <0)
                throw new ArgumentException("Attendees argument must be positive");
            var numberOfVechicles = attendees / seats;
            var modulo = attendees % seats;
            if (modulo > 0)
                numberOfVechicles++;
            return numberOfVechicles;
        }
    }
}
