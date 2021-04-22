using System;
using System.Collections.Generic;
using System.Linq;

namespace IterationLib
{

    public class Program
    {
       
        public static void Main(string[] args)
        {
            //ignore
        }
    }
    public class Exercises
    {
        // returns the lowest number in the array nums
        public static int Lowest(int[] nums)
        {
            if (nums.Length == 0)
                return int.MaxValue;
            return nums.Min();
        }

        // returns the sum of all numbers between 1 and n inclusive that are divisible by either 2 or 5
        public static int SumEvenFive(int max)
        {
            int sum = 0;
            for (int i = 1; i <= max; i++)
            {
                if (i % 2 == 0 || i % 5 == 0)
                    sum += i;
            }
            return sum;
        }

        // Returns the a string containing the count of As, Bs, Cs and Ds in the parameter string
        // all other letters are ignored
        public static string CountLetters(string input)
        {
            var count = new Dictionary<char, int>() { { 'A', 0 }, { 'B', 0 }, { 'C', 0 }, { 'D', 0 } };

            foreach (char c in input)
            {
                if (count.ContainsKey(c))
                    count[c] += 1;
            }
            return $"A:{count['A']} B:{count['B']} C:{count['C']} D:{count['D']}";
        }
    }
}