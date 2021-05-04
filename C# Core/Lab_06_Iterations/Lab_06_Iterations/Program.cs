using System;

namespace Lab_06_Iterations
{
    class Program
    {
        static void Main()
        {
            //Loops
            string countingDown = "";
            for (int i = 100; i >= 0; i--)
            {
                countingDown += "" + i + ", ";
            }

            Console.WriteLine(countingDown);

            int[] intArray = { 1, 2, 3, 4, 5 };

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }

            for (int i = intArray.GetUpperBound(0); i >= 0; i--)
            {
                Console.WriteLine(intArray[i]);
            }

            foreach (var number in intArray)
            {
                Console.WriteLine(number);
            }

            int counter = 0;

            while (counter < 10)
            {
                Console.WriteLine("Counter is at: " + counter);
                counter++;
            }

            do
            {
                Console.WriteLine("Counter is at: " + counter);
                counter++;
            } while (counter < 10);

            int sum = 0;

            for (int i = 1; i <= 100; i++)
            {
                sum += i;
            }

            Console.WriteLine(sum);

            string nishString = "NISH IS KING";

            foreach (char c in nishString.ToLower())
            {
                Console.WriteLine(c);
            }

            //Breaking out of loops early
            for (int i = 0; i < 10; i++)
            {
                if (i == 3)
                {
                    break;
                }

                Console.WriteLine("In loops at i = " + i);
            }

            counter = 0;

            while (counter < 10)
            {
                counter++;

                if (counter < 4)
                    continue;

                Console.WriteLine("This while loop outputs: " + counter);
            }

            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine(i);
                if (i % 15 == 0)
                    break;
            }
        }
    }
}
