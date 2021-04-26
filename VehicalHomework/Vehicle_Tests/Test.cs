using NUnit.Framework;
using VehicleHomework;

namespace Vehicle_Tests
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
    }
}