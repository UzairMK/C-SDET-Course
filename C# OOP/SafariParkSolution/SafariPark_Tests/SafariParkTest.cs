using NUnit.Framework;
using SafariPark;

namespace SafariPark_Tests
{
    public class Tests
    {
        [TestCase("Uzair","Khan", "Uzair Khan")]
        [TestCase("","", " ")]
        public void GetFullNameTest(string fName, string lName, string expected)
        {
            var p = new Person(fName, lName);
            var actual = p.GetFullName();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AgeTest()
        {
            var p = new Person("A", "B", 30);
            Assert.AreEqual(30, p.Age);
        }
    }
}