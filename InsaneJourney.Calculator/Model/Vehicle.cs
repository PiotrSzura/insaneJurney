using System.Collections.Generic;

namespace InsaneJourney.Calculator.Model
{
    public class Vehicle
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public ushort NumberOfSeats { get; set; }
        public List<FuelConsumption> FuelConsumptions { get; set; }
    }
}
