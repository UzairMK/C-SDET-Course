using System;

namespace FizzBuzzApp
{
    public static class FizzBuzz
    {
        static void Main()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"{Input(i)}");
            }
        }

        public static string Input(int i)
        {
            if (i % 15 == 0)
                return "FizzBuzz";
            if (i % 3 == 0)
                return "Fizz";
            if (i % 5 == 0)
                return "Buzz";
            return i.ToString();
        }
    }
}
