using NUnit.Framework;
using System;
using Lab_09_Exceptions;

namespace Tests
{
    public class Tests
    {
        [TestCase(4)]
        [TestCase(-1)]
        public void TestingAddAnimals(int pos)
        {
            var ex = Assert.Throws<IndexOutOfRangeException>(() => Program.AddAnimal(pos, "animal"));
            Assert.AreEqual("Animal not allowed here", ex.Message, "Error messages don't match");
        }
    }
}