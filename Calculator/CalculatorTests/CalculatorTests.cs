using NUnit.Framework;
using System;
using CalculatorLib;

namespace CalculatorTests
{
    public class Tests
    {
        [TestCase(3,4,7)]
        [TestCase(System.Int32.MaxValue, 1, System.Int32.MaxValue)]
        [TestCase(2000000000, 2000000000, System.Int32.MaxValue)]
        public void AddIsCorrect(int a, int b, int expected)
        {
            int actual = Calculator.Add(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3,4,-1)]
        [TestCase(System.Int32.MinValue, 1, System.Int32.MinValue)]
        [TestCase(-2000000000, 2000000000, System.Int32.MinValue)]
        public void SubtractIsCorrect(int a, int b, int expected)
        {
            int actual = Calculator.Subtract(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3,4,12)]
        [TestCase(-2000000, 2000000, System.Int32.MinValue)]
        [TestCase(-2000000, -2000000, System.Int32.MaxValue)]
        public void MultiplyIsCorrect(int a, int b, int expected)
        {
            int actual = Calculator.Multiply(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3,4,0)]
        [TestCase(System.Int32.MaxValue, -1, -System.Int32.MaxValue)]
        [TestCase(1, 0, int.MaxValue)]
        public void DivideIsCorrect(int a, int b, int expected)
        {
            try
            {
                int actual = Calculator.Divide(a, b);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception)
            {
                if (b == 0)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
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