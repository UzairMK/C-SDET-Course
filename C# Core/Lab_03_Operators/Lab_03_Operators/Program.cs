using System;

namespace Lab_03_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3, b = 1, c = 2;
            b = a++;
            c = ++a;

            var sum = a + b - c;

            var years = 11;
            var dogYears = years * 7;

            var pounds = 15;
            var kilos = pounds / 2.2;

            var d = 5.0 / 2.0;
            var e = 5 / 2;
            var f = 5.0 / 2;

            //What is 26 days in weeks and days
            var days = 26;
            Console.WriteLine($"There is/are {days/7} week(s) and {days%7} day(s) in {days} day(s)");
            
            //Bitwise operators
            Console.WriteLine($"5 & 1 = {5 & 1}");
            Console.WriteLine($"5 | 1 = {5 | 1}");
            Console.WriteLine($"5 ^ 1 = {5 ^ 1}");

            Console.WriteLine($"Left shift: 9 << 3 = {9 << 3}");
            Console.WriteLine($"Right shift: 9 >> 3 = {9 >> 3}");

        }
    }
}
