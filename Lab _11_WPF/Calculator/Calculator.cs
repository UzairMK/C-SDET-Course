using System;

namespace CalculatorLib
{
    public static class Calculator
    {
        public static int Add(int a, int b) => b > int.MaxValue - a ? throw new Exception("Result above calculator's maximum value") : b < int.MinValue + a ? throw new Exception("Result below calculator's minimum value") : a + b;

        public static int Subtract(int a, int b) => a < int.MinValue + b ? throw new Exception("Result below calculator's minimum value") : -b > int.MaxValue - a ? throw new Exception("Result above calculator's maximum value") : a - b;

        public static int Multiply(int a, int b) => (long)a * b > int.MaxValue ? throw new Exception("Result above calculator's maximum value") : (long)a * b < int.MinValue ? throw new Exception("Result below calculator's minimum value") : a * b;

        public static int Divide(int a, int b) => b != 0 ? a / b : throw new Exception("You can not divide by 0");

        public static int Modulo(int a, int b) => b != 0 ? a / b : throw new Exception("You can not divide by 0");
    }
}
