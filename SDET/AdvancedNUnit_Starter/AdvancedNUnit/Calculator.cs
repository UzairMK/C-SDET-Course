using System;

namespace AdvancedNUnit
{
    public class Calculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        public int Divide(int x, int y)
        {
            if (y == 0) throw new ArgumentException("Can't divide by 0");
            return x / y;
        }

        public bool DivisibleBy3(int v)
        {
            return v % 3 == 0;
        }
    }
}
