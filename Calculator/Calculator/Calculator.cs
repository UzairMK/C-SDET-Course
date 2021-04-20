using System;

namespace CalculatorLib
{
    public static class Calculator
    {
        public static int Add(int a, int b) => b > int.MaxValue - a ? int.MaxValue : b < int.MinValue + a ? int.MinValue : a + b;

        public static int Subtract(int a, int b) => a <  int.MinValue + b ? int.MinValue : -b > int.MaxValue - a ? int.MaxValue : a - b;
      
        public static int Multiply(int a, int b) => (long)a * b > int.MaxValue ? int.MaxValue : (long)a * b < int.MinValue ? int.MinValue : a * b;

        public static int Divide(int a, int b) => b != 0 ? a / b : throw new Exception("You can not divide by 0");

        public static int Modulo(int a, int b) => a < 0 && b < 0 ? -(a % b) : a % b;
    }
}
