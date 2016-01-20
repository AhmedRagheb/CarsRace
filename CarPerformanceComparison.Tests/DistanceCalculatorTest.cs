using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarPerformanceComparison.Data;
using CarPerformanceComparison.Services;

namespace CarPerformanceComparison.Tests
{
    [TestClass]
    public class DistanceCalculatorTest
    {
        private DistanceCalculator _distanceCalculator;
        [TestInitialize]
        public void Initialize()
        {
            _distanceCalculator = new DistanceCalculator();
        }

        [TestMethod]
        public void TestZeroDistance()
        {
            var returnVal = _distanceCalculator.CalculateDistance(new Position(0.0, 0.0), new Position(0.0, 0.0));

            Assert.AreEqual(returnVal, 0.0);
        }

        [TestMethod]
        public void TestNonZeroDistance()
        {
            var returnVal = _distanceCalculator.CalculateDistance(
                new Position(35.9559783333333, -5.70973333333333),
                new Position(35.9123433333333, -5.99793166666667));
            
            Assert.AreEqual(returnVal, 26397.276124025455);
        }

        [TestMethod]
        public void TestTwoPositiveCoordinates()
        {
            var returnVal = _distanceCalculator.CalculateDistance(
                new Position(29.9559783333333, 28.70973333333333),
                new Position(31.9123433333333, 32.99793166666667));

            Assert.AreEqual(returnVal, 463196.00474288163);
        }

        [TestMethod]
        public void TestTwoNegativeCoordinates()
        {
            var returnVal = _distanceCalculator.CalculateDistance(
                new Position(-5.189289, -6.08264166666667),
                new Position(-5.99981987, -6.99895981));

            Assert.AreEqual(returnVal, 135667.14736988902);
            
            
        }

        [TestMethod]
        public void TestNotNullDistance()
        {
            var returnVal = _distanceCalculator.CalculateDistance(
                new Position(-5.189289, -6.08264166666667),
                new Position(-5.99981987, -6.99895981));

            Assert.IsNotNull(returnVal);
        }

        [TestMethod]
        public void TestNotNegativeDistance()
        {
            var returnVal = _distanceCalculator.CalculateDistance(
                new Position(35.9559783333333, -5.70973333333333),
                new Position(35.9123433333333, -5.99793166666667));

            Assert.IsTrue(returnVal > -1);
        }
    }
}
