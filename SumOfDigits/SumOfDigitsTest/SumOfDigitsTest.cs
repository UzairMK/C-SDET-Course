using NUnit.Framework;
using SumOfDigits;

namespace SumOfDigitsTest
{
    public class Tests
    {
        [TestFixture]
        public class SumOfDigitsTest
        {


            [SetUp]
            public void SetUp()
            {

            }

            [TestCase(16, 7)]
            [TestCase(456, 6)]
            [TestCase(38, 2)]
            [TestCase(1, 1)]
            [TestCase(0, 0)]
            [TestCase(123456789, 9)]
            public void Tests(long a, long expected)
            {
                long actual = SumOfDigits.SumOfDigits.sumMethod(a) ;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}