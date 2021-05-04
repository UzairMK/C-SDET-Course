using NUnit.Framework;
using SafariPark;
using System;

namespace Vehicles_Tests
{
    public class Tests
    {
        [Test]
        public void WhenADefaultVehicleMovesTwiceItsPositionIs20()
        {
            Vehicle v = new Vehicle();
            var result = v.Move(2);
            Assert.AreEqual(20, v.Position);
            Assert.AreEqual("Moving along 2 times", result);
        }

        [Test]
        public void WhenAVehicleWithSpeed40IsMovedOnceItsPositionIs40()
        {
            Vehicle v = new Vehicle(5, 40);
            var result = v.Move();
            Assert.AreEqual(40, v.Position);
            Assert.AreEqual("Moving along", result);
        }

        [Test]
        public void NegativeSpeedMovesVehicleBackwards()
        {
            Vehicle v = new Vehicle(5, -10);
            var result = v.Move();
            Assert.AreEqual(-10, v.Position);
            Assert.AreEqual("Moving along", result);
        }

        [TestCase(5, -1, 0)]
        [TestCase(5, 3, 3)]
        [TestCase(5, 6, 5)]
        public void NumberOfPassengersTests(int capacity, int passengers, int expected)
        {
            Vehicle v = new Vehicle(capacity);
            v.NumPassengers = passengers;
            var actual = v.NumPassengers;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AirplaneGivenTest()
        {
            var a = new Airplane(200, 100, "JetsRUs") { NumPassengers = 150 };
            a.Ascend(500);
            Assert.AreEqual("Moving along 3 times at an altitude of 500 metres.", a.Move(3));
            Assert.AreEqual("Thank you for flying JetsRUs: SafariPark.Airplane capacity: 200 passengers: 150 speed: 100 position: 300 altitude: 500.", a.ToString());
            a.Decend(200);
            Assert.AreEqual("Moving along at an altitude of 300 metres.", a.Move());
            a.Move();
            Assert.AreEqual("Thank you for flying JetsRUs: SafariPark.Airplane capacity: 200 passengers: 150 speed: 100 position: 500 altitude: 300.", a.ToString());
        }

        [Test]
        public void AirplaneCanNotFlyBelowZeroAltitude()
        {
            var a = new Airplane(200);
            a.Decend(100);
            Assert.AreEqual(0, a.Altitude);
        }

        [Test]
        public void AirplaneMultipleAscendsAndDecends()
        {
            var a = new Airplane(200);
            a.Ascend(100);
            a.Ascend(101);
            a.Ascend(102);
            a.Decend(10);
            a.Decend(20);
            a.Decend(30);
            Assert.AreEqual(243, a.Altitude);
        }

        [Test]
        public void AirplaneDecendBelowZeroThanAscend()
        {
            var a = new Airplane(200);
            a.Ascend(100);
            a.Decend(200);
            a.Ascend(50);
            Assert.AreEqual(50, a.Altitude);
        }

        [Test]
        public void AirplaneMultipleMoves()
        {
            var a = new Airplane(200,1,"");
            a.Move(-3);
            a.Move(2);
            a.Move();
            a.Move(-1);
            a.Move(5);
            a.Move(1000);
            Assert.AreEqual("Thank you for flying : SafariPark.Airplane capacity: 200 passengers: 0 speed: 1 position: 1004 altitude: 0.", a.ToString());
        }

        [Test]
        public void AirplaneValuesOutOfRange()
        {
            var a = new Airplane(200, int.MaxValue, "");
            a.Ascend(2000000000);
            a.Ascend(int.MaxValue);
            Assert.AreEqual(int.MaxValue, a.Altitude);
            //a.Move(2);
            //Assert.AreEqual(int.MaxValue, a.Position);
            //a.Move(-3);
            ////Assert.AreEqual(int.MinValue, a.Position);
        }
    }
}