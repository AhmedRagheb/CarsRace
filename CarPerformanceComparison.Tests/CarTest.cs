using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarPerformanceComparison.Data;
using CarPerformanceComparison.Services;

namespace CarPerformanceComparison.Tests
{
    [TestClass]
    public class CarTest
    {
        private CarFactory _carFactory;

        [TestInitialize]
        public void Initialize()
        {
            _carFactory = new CarFactory();
        }

        [TestMethod]
        public void TestCreateCar()
        {
            var car = _carFactory.Create(
                "Test car 1",
                new ConsumptionAtSpeed(new Range<double>(0, 5), 0.5),
                new ConsumptionAtSpeed(new Range<double>(5, 9.3), 0.7),
                20);

            Assert.IsNotNull(car);
        }

        [TestMethod]
        public void TestCreateCarMaxSpeed()
        {
            var car = _carFactory.Create(
                "Test car 1",
                new ConsumptionAtSpeed(new Range<double>(0, 14.3), 0.9),
                new ConsumptionAtSpeed(new Range<double>(15, 20.5), 1.4),
                27);

            Assert.AreEqual(27, car.MaxSpeed);
        }
        
        [TestMethod]
        public void TestCreateCarName()
        {
            var car = _carFactory.Create(
                "Test car 1",
                new ConsumptionAtSpeed(new Range<double>(0, 14.3), 0.9),
                new ConsumptionAtSpeed(new Range<double>(15, 20.5), 1.4),
                27);

            Assert.AreEqual("Test car 1", car.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNegativeMaxSpeed()
        {
            var car = _carFactory.Create(
               "Test car 1",
               new ConsumptionAtSpeed(new Range<double>(0, 9), 0.4),
               new ConsumptionAtSpeed(new Range<double>(10, 13.3), 0.9),
               -20);

            Assert.IsNull(car);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNonZeroMaxSpeed()
        {
            var car = _carFactory.Create(
               "Test car 1",
               new ConsumptionAtSpeed(new Range<double>(0, 5), 0.8),
               new ConsumptionAtSpeed(new Range<double>(15, 30), 2.0),
               0);

            Assert.IsNull(car);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullLowSpeed()
        {
            var car = _carFactory.Create(
               "Test car 1",
               null,
               new ConsumptionAtSpeed(new Range<double>(10, 30), 1.5),
               20);

            Assert.IsNull(car);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullHighSpeed()
        {
            var car = _carFactory.Create(
               "Test car 1",
               new ConsumptionAtSpeed(new Range<double>(2, 15), 0.9),
               null,
               20);

            Assert.IsNull(car);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNegativeConsumption()
        {
            var car = _carFactory.Create(
               "Test car 1",
               new ConsumptionAtSpeed(new Range<double>(0, 5), -10),
               new ConsumptionAtSpeed(new Range<double>(20, 50), 18),
               20);

            Assert.IsNull(car);
        }
        
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullRange()
        {
            var car = _carFactory.Create(
               "Test car 1",
               new ConsumptionAtSpeed(null, 10),
               new ConsumptionAtSpeed(new Range<double>(20, 50), 18),
               20);

            Assert.IsNull(car);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRangeValuesMinLessThanOrEqualMax()
        {
            var car = _carFactory.Create(
               "Test car 1",
               new ConsumptionAtSpeed(new Range<double>(50, 49), 10),
               new ConsumptionAtSpeed(new Range<double>(50, 20), 18),
               20);

            Assert.IsNull(car);
        }


    }
}
