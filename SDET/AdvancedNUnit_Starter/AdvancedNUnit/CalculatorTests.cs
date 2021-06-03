using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedNUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        [Category("Happy Path")]
        public void Add_Always_ReturnsExpectedResult()
        {
            // Arrange
            var subject = new Calculator();
            // Act
            var result = subject.Add(2, 4);
            // Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        [Category("Happy Path")]
        public void ConstraintModel()
        {
            // Arrange
            var subject = new Calculator();
            // Act and Assert
            Assert.That(subject.Add(2, 4), Is.EqualTo(6));
            Assert.That(subject.DivisibleBy3(6));
            Assert.That(subject.DivisibleBy3(7), Is.False);
        }

        [Test]
        public void ClassicAssertModel_ListTest()
        {
            // Arrange
            var myList = new List<int>() { 1, 2, 3, 4 };
            // Act and Assert
            Assert.AreEqual(1,myList.Where(x => x == 5).Count());
        }

        [Test]
        public void ConstraintAssertModel_ListTest()
        {
            // Arrange
            var myList = new List<int>() { 1, 2, 3, 4 };
            // Act and Assert
            Assert.That(myList, Has.Exactly(1).EqualTo(5));
        }

        [Test]
        public void ConstraintAssertModel_ListTest_2()
        {
            // Arrange
            var myList = new List<int>() { 1, 2, 3, 4 };
            // Act and Assert
            Assert.That(myList, Does.Contain(5));
        }

        [Test]
        public void ConstraintAssertModel_ListTest_3()
        {
            // Arrange
            var myList = new List<int>() { 1, 2, 3, 4 };
            // Act and Assert
            Assert.That(myList, Has.Count.GreaterThan(4));
        }

        [Test]
        [Category("Unhappy Path")]
        public void ClassicAssertModel_ThrowingException()
        {
            // Arrange
            var subject = new Calculator();
            // Act and Assert
            var ex = Assert.Throws<ArgumentException>(() => subject.Divide(3,0));
            Assert.AreEqual(ex.Message, "Can't divide by 0");
        }

        [Test]
        public void ConstraintAssertModel_ThrowingException()
        {
            // Arrange
            var subject = new Calculator();
            // Act and Assert
            var ex = Assert.Throws<ArgumentException>(() => subject.Divide(3, 0));
            Assert.That(() => subject.Divide(3,0), Throws.ArgumentException.And.Message.Contains("Can't divide by 0"));
        }

        [Test]
        public void TestFruitList()
        {
            // Arrange
            var fruitList = new List<string>() { "apple", "pear", "banana", "peach" };
            // Act and Assert
            Assert.That(fruitList, Does.Contain("apple"));
            Assert.That(fruitList, Has.Exactly(2).StartsWith("PEA").IgnoreCase);
            Assert.That(fruitList, Has.Count.EqualTo(4));
        }

        [TestCaseSource("AddCase")]
        [Category("Happy Path")]
        public void Add_Method(int x, int y, int expected)
        {
            // Arrange
            var subject = new Calculator();
            // Act and Assert
            Assert.That(subject.Add(x, y), Is.EqualTo(expected));
        }

        public static object[] AddCase =
        {
            new int[] { 2,4,6 },
            new int[] {-2,3,1}
        };
    }
    
}