using System;
using System.Collections.Generic;
using System.Globalization;
using Decoder;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class CalculatorTests
    {
        private Airplane _airplane1;
        private Airplane _airplane2;
        private Airplane _airplane3;
        private Airplane _airplane4;

        private List<Airplane> _airplaneList;

        private ICalculator _calculator;

        [SetUp]
        public void Setup()
        {
            string timeStamp1 = "20151006213456001";
            string timeStamp2 = "20151006213457001";
            _airplane1 = new Airplane("ACR101", 40000, 40000, 8000, "20151006213456001");
        }

        // Der skal laves således at den ikke kan tage negativ tid eller hvis tiden er 0

        // Plane moved 100 m in 1000 milliseconds, 40000 to 40100, expected 100 meter/second
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR101", 40100, 40000, 8000, "20151006213457001", 100)]
        // Plane moved 100 m in 1000 milliseconds (backwards), 40000 to 39900, expected 100 meter/second
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR101", 39900, 40000, 8000, "20151006213457001", 100)]
        // Plane not moved
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR101", 40000, 40000, 8000, "20151006213457001", 100)]
        // Plane moved 135 m on x-axis and 120 m in y-akis, 40000 to 40135 and 40000 to 40120, expected 180 meter/second
        [TestCase("ACR101", 40000, 40000, 8000, "20151006213456001", "ACR101", 40135, 40120, 8000, "20151006213457001", 100)]
        // Plane moved 135 m on x-axis and 120 m in y-akis (backwards), 40135 to 40000 and 40120 to 40000, expected 180 meter/second
        [TestCase("ACR101", 40135, 40120, 8000, "20151006213456001", "ACR101", 40000, 40000, 8000, "20151006213457001", 100)]
        public void CalculateSpeed_AirplaneFoundInList_ReturnsSpeed(string plane1Tag, int plane1X, int plane1Y,
            int plane1Altitude, string plane1Timestamp,
            string plane2Tag, int plane2X, int plane2Y, int plane2Altitude, string plane2Timestamp, double result)
        {
            string format = "yyyyMMddHHmmssfff";
            DateTime plane1Time = DateTime.ParseExact(plane1Timestamp, format, CultureInfo.InvariantCulture);
            DateTime plane2Time = DateTime.ParseExact(plane2Timestamp, format, CultureInfo.InvariantCulture);

            var airplane1 = new Airplane(plane1Tag, plane1X, plane1Y, plane1Altitude, plane1Time);
            var airplane2 = new Airplane(plane2Tag, plane2X, plane2Y, plane2Altitude, plane2Time);

            List<Airplane> airplaneList = new List<Airplane>();

            airplaneList.Add(airplane1);

            //Unit under test/uut
            Calculator calculator = new Calculator();

            calculator.NewPositions(airplaneList);

            var actual = calculator.CalculateSpeed(airplane2);

            Assert.AreEqual(actual, result);
        }
    }
}
