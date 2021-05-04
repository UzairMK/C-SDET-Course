using NUnit.Framework;
using Lab_04_Methods_UnitTesting;

namespace Lab_04_Methods_UnitTesting_Tests
{
    public class Tests
    {
        private int _result;
        private int _sum;

        [SetUp]
        public void Setup()
        {
            //Arrange and Act
            _result = Program.TripleCalc(2, 2, 2, out _sum);
        }

        [Test]
        public void ProductIsCorrect()
        {
            //Assert
            Assert.AreEqual(8, _result);
        }

        [Test]
        public void SumIsCorrect()
        {
            //Assert
            Assert.AreEqual(6, _sum);
        }

        [TestCase(2, 2, 2, 8)]
        [TestCase(3, 3, 3, 27)]
        public void ProductIsCorrect(int a, int b, int c, int expected)
        {
            var actual = Program.TripleCalc(a, b, c, out int sum);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 2, 2, 6)]
        [TestCase(3, 3, 3, 9)]
        public void SumIsCorrect(int a, int b, int c, int expected)
        {
            var result = Program.TripleCalc(a, b, c, out int actual);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}