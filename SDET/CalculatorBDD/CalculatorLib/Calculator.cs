using System;
using System.Collections.Generic;

namespace CalculatorLib
{
    public class Calculator
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public List<int> NumList { get; set; }

        public int Add()
        {
            return Num1 + Num2;
        }

        public int Subtract()
        {
            return Num1 - Num2;
        }

        public int Multiply()
        {
            return Num1 * Num2;
        }

        public int Divide()
        {
            if (Num2 == 0)
                throw new Exception("Can not divide by zero");
            return Num1 / Num2;
        }

        public int SumOfEvenNumbersInList()
        {
            int sum = 0;
            foreach (int Num in NumList)
            {
                if (Num % 2 == 0)
                    sum += Num;
            }
            return sum;
        }
    }
}
