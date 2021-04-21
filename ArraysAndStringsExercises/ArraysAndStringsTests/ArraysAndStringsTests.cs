using NUnit.Framework;
using ArraysAndStringsLib;
using Microsoft.VisualBasic;

namespace ArraysAndStringsTests
{
    public class StringsTests
    {
        [TestCase(5, "Main Street", "Stone", "ST6 2RQ", "5 Main Street, Stone ST6 2RQ.")]
        [TestCase(27, "Town Road", "Hull", "H12 8AA", "27 Town Road, Hull H12 8AA.")]
        public void Address_GivenItsComponents_ReturnsAFormattedAddressString
            (int number, string street, string city, string postcode, string expAddress)
        {
            var result = Exercises.Address(number, street, city, postcode);
            Assert.AreEqual(expAddress, result);
        }
        [TestCase(33, 40, "You got 33 out of 40: 82.5%")]
        [TestCase(18, 65, "You got 18 out of 65: 27.7%")]
        public void GivenATestScore_Scorer_ReturnsAFormattedString(int score, int outOf, string expString)
        {
            var result = Exercises.Scorer(score, outOf);
            Assert.AreEqual(expString, result);
        }
        [Test]
        public void GivenAString_ParseNum_ReturnsTheDoubleRepresentedByTheString()
        {
            Assert.AreEqual(3.14159, Exercises.ParseNum("3.14159"));
        }
        [Test]
        public void GivenAnInvalidDoubleString_ParseNum_ReturnsMinus999()
        {
            Assert.AreEqual(-999, Exercises.ParseNum("twenty-two"));
        }

        [TestCase("  Cathy", 10, "CATHY0123456789")]
        [TestCase("", 4, "0123")]
        [TestCase(" Piano  ", 12, "PIANO01234567891011")]
        public void GivenAString_ManipulateString_ReturnsATransformedString(string original, int num, string expected)
        {
            var result = Exercises.ManipulateString(original, num);
            Assert.AreEqual(expected, result);
        }
    }
}