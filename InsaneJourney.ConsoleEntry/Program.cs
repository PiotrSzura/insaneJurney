using System;
using InsaneJourney.Calculator.Model;
using InsaneJourney.XmlFileRepository;

namespace InsaneJourney.ConsoleEntry
{
    class Program
    {
        private const string GetAttendeesMessage = "Please enter number of attendees";
        private const string GetAttendeesErrorMessage = "Number of attendees must be integer. Please try again";
        private const string GetTripLengthMessage = "Please enter trip length in km";
        private const string GetTripLengthErrorMessage = "Number of attendees must be numeric. Please try again";
        private const string ResultMessage = "The best option is: \n ";

        private static bool _attendeesNotSupplied = true;
        private static bool _tripLengthNotSupplied = true;

        static void Main()
        {
            int attendees = 0;
            decimal tripLength = 0M;

            while (_attendeesNotSupplied)
            {
                attendees = GetAttendees();
            }

            while (_tripLengthNotSupplied)
            {
                tripLength = GetTripLength();
            }

            var repository = new XmlRepository();
            var calculator = new Calculator.CalculatorFactory().GetCalculator(new CalculationRequest{Attendees = attendees, TripLength = tripLength});
            var result = calculator.Calculate(repository);

            if (result.CheapestTrip != null)
            {
                Console.WriteLine(ResultMessage);
                foreach (var calculation in result.CheapestTrip.Calculations)
                {
                    Console.WriteLine("Type: "+calculation.VehicleType);
                    Console.WriteLine("Name: "+calculation.VehicleName);
                    Console.WriteLine("Option km/h: " + calculation.FuelcConsumptionOption);
                    
                    Console.WriteLine("Vehicle required: "+calculation.RequiredVechicles );
                    Console.WriteLine("Total Fuel Consumption: " + calculation.TotalFuelConsumption);
                    Console.WriteLine();
                    
                }

            }
            else
            Console.WriteLine(result.Message);
           
           
            Console.ReadKey();
        }

        private static int GetAttendees()
        {
            int atendees;
            
            Console.WriteLine(GetAttendeesMessage);
            var atendeesString = Console.ReadLine();
            
            if (!int.TryParse(atendeesString, out atendees))
                Console.WriteLine(GetAttendeesErrorMessage);
            else
                _attendeesNotSupplied = false;
            
            return atendees;
        }

        private static decimal GetTripLength()
        {
            decimal tripLength;

            Console.WriteLine(GetTripLengthMessage);
            var tripLengthString = Console.ReadLine();

            if (!decimal.TryParse(tripLengthString, out tripLength))
                Console.WriteLine(GetTripLengthErrorMessage);

            else
                _tripLengthNotSupplied = false;

            return tripLength;
        }
        
    }
}