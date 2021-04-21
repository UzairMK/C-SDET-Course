using NUnit.Framework;
using System;
using CalculatorLib;

namespace CalculatorTests
{
    public class Tests
    {
        [TestCase(3,4,7)]
        public void AddIsCorrect(int a, int b, int expected)
        {
            int actual = Calculator.Add(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(System.Int32.MaxValue, 1)]
        [TestCase(2000000000, 2000000000)]
        [TestCase(-2000000000, -2000000000)]
        public void AddBoundaryCheck(int a, int b)
        {
            Assert.Throws<Exception>(() => Calculator.Add(a, b));
        }

        [TestCase(3,4,-1)]
        public void SubtractIsCorrect(int a, int b, int expected)
        {
            int actual = Calculator.Subtract(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(System.Int32.MinValue, 1)]
        [TestCase(-2000000000, 2000000000)]
        [TestCase(2000000000, -2000000000)]
        public void SubtractBoundaryCheck(int a, int b)
        {
            Assert.Throws<Exception>(() => Calculator.Subtract(a, b));
        }

        [TestCase(3,4,12)]
        public void MultiplyIsCorrect(int a, int b, int expected)
        {
            int actual = Calculator.Multiply(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-2000000, 2000000)]
        [TestCase(-2000000, -2000000)]
        public void MultiplyBoundaryCheck(int a, int b)
        {
            Assert.Throws<Exception>(() => Calculator.Multiply(a, b));
        }

        [TestCase(3,4,0)]
        [TestCase(System.Int32.MaxValue, -1, -System.Int32.MaxValue)]
        public void DivideIsCorrect(int a, int b, int expected)
        {
            int actual = Calculator.Divide(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 0)]
        public void DivideByZeroCheck(int a, int b)
        {
            Assert.Throws<Exception>(() => Calculator.Divide(a, b));
        }

        [TestCase(3,4,3)]
        [TestCase(-2000000000, System.Int32.MaxValue, -2000000000)]
        [TestCase(-2000000000, System.Int32.MinValue, 2000000000)]
        [TestCase(System.Int32.MaxValue, 2000000000, (System.Int32.MaxValue - 2000000000))]
        public void ModuloIsCorrect(int a, int b, int expected)
        {
            int actual = Calculator.Modulo(a, b);
            Assert.AreEqual(expected, actual);
        }
    }
}