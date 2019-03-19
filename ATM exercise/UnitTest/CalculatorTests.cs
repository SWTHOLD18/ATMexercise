using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            string timeStamp1 = "20151006213456001";
            string timeStamp2 = "20151006213457001";
            _airplane1 = new Airplane("ACR101", 40000, 40000, 8000, "20151006213456001");
        }
    }
}
