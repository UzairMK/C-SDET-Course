using NUnit.Framework;
using FizzBuzzApp;

namespace FizzBuzz_Tests
{
    public class FizzBuzzShould
    {
        [TestCase(1,"1")]
        [TestCase(2,"2")]
        [TestCase(4,"4")]
        public void NotDivisibleBy3Or5(int x, string expected)
        {
            var actual = FizzBuzz.Input(x);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenThree_Return_Fizz()
        {
            Assert.That(FizzBuzz.Input(3), Is.EqualTo("Fizz"));
        }

        [TestCase(6)]
        [TestCase(9)]
        public void GivenANumberDivisibleByThree_Return_Fizz(int x)
        {
            var actual = FizzBuzz.Input(x);
            Assert.That(actual, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GivenFive_Return_Buzz()
        {
            Assert.That(FizzBuzz.Input(5), Is.EqualTo("Buzz"));
        }

        [TestCase(10)]
        [TestCase(20)]
        public void GivenANumberDivisibleByFive_Return_Buzz(int x)
        {
            var actual = FizzBuzz.Input(x);
            Assert.That(actual, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GivenFifteen_Return_FizzBuzz()
        {
            Assert.That(FizzBuzz.Input(15), Is.EqualTo("FizzBuzz"));
        }

        [TestCase(30)]
        [TestCase(45)]
        public void GivenANumberDivisibleByFifteen_Return_FizzBuzz(int x)
        {
            var actual = FizzBuzz.Input(x);
            Assert.That(actual, Is.EqualTo("FizzBuzz"));
        }
    }
}