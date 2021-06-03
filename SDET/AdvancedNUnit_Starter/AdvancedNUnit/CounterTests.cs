using NUnit.Framework;

namespace AdvancedNUnit
{
    [TestFixture]
    //[Ignore("Not using these tests yet")]
    public class CounterTests
    {
        private Counter _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Counter(6);
        }

        [Test]
        public void Increment_IncreaseCountByOne()
        {
            _sut.Increment();
            Assert.That(_sut.Count, Is.EqualTo(7));
        }
        [Test]
        public void Decrement_DecreasesCountByOne()
        {
            _sut.Decrement();
            Assert.That(_sut.Count, Is.EqualTo(5));
        }
    }
}
