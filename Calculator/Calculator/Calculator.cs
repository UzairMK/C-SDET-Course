using System;

namespace CalculatorLib
{
    public static class Calculator
    {
        public static int Add(int a, int b)
        {
            if ((long)a + b > int.MaxValue)
                return int.MaxValue;
            return a + b;
        }
        public static int Subtract(int a, int b)
        {
            if ((long)a - b < int.MinValue)
                return int.MinValue;
            return a - b;
        }
        public static int Multiply(int a, int b)
        {
            if ((long)a * b > int.MaxValue)
                return int.MaxValue;
            if ((long)a * b < int.MinValue)
                return int.MinValue;
            return a * b;
        }
        public static int Divide(int a, int b)
        {
            return a / b;
        }
        public static int Modulo(int a, int b)
        {
            if (a < 0 && b < 0)
            {
                return -(a % b); 
            }
            else
            {
                return a % b;
            }
        }
    }
}
