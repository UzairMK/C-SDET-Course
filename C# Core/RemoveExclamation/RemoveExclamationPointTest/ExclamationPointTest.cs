using NUnit.Framework;
using RemoveExclamation;

namespace RemoveExclamationPointTest
{
    public class ExclamationPointTest
    {

        [Test]
        public void Remove_ExclamationPoint_PlaceOneExclamationPointAtEnd()
        {
            Assert.AreEqual("Hi", Remove.RemoveLastExclamationMark("Hi!"));
            Assert.AreEqual("Hi!!", Remove.RemoveLastExclamationMark("Hi!!!"));
            Assert.AreEqual("!Hi", Remove.RemoveLastExclamationMark("!Hi"));
            Assert.AreEqual("!Hi", Remove.RemoveLastExclamationMark("!Hi!"));
            Assert.AreEqual("Hi! Hi", Remove.RemoveLastExclamationMark("Hi! Hi"));
            Assert.AreEqual("Hi", Remove.RemoveLastExclamationMark("Hi"));
        }
    }
}