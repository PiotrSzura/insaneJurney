
using System;
using InsaneJourney.Calculator.Calculation.CalculationRules;
using InsaneJourney.Calculator.Model;
using NUnit.Framework;

namespace InsaneJurney.Calculator.Tests.Calculation.CalculationRules
{
    [TestFixture]
    public class CalculationRulesTests
    {
        [TestCase(10, (ushort)3, Result = 4)]
        [TestCase(31, (ushort)5, Result = 7)]
        [TestCase(1, (ushort)1, Result = 1)]
        [TestCase(-10, (ushort)3, ExpectedException = typeof(ArgumentException))]
        public int DriversIncludedRequiredVehicleRuleTest(int attendees, ushort seats)
        {
            var rule = new DriversIncludedRequiredVehicleRule();
            return rule.GetNublerOfRequiredVechicles(attendees, seats);
        }

        [TestCase]
        public void FuelConsumptionCalculationRuleTest()
        {
            var rule = new FuelConsumptionCalculationRule();
            Assert.AreEqual(995M, rule.PerformCalculation(10, new FuelConsumption { Name = "80", Value = 19.9M }, 500));
            Assert.AreEqual(45900M, rule.PerformCalculation(10, new FuelConsumption { Name = "120", Value = 45.9M }, 10000));
            Assert.AreEqual(25M, rule.PerformCalculation(1, new FuelConsumption { Name = "60", Value = 5M }, 500));
        }
    }
}
