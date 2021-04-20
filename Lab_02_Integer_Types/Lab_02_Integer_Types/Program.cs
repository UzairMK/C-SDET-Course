using System;

namespace Lab_02_Integer_Types
{
    class Program
    {
        //Integer overflow and underflow.
        static void Main(string[] args)
        {
            uint a = Int32.MaxValue;
            uint b = a + 1;

            Console.WriteLine(a);
            Console.WriteLine(b);

            float sum = 0;

            for (int index = 0; index < 1000; index++)
            {
                sum += 1 / 3.0f;
            }

            Console.WriteLine("1/3 added 1000 times (" + sum + ") should be the same as 1/3 multiplied by 1000 (" + (1000/3.0f) + ")");

            char c = 'c';
            //Implicit casting
            int d = c;
            //Explicit casting
            char e = (char)d;

            Console.WriteLine($"char c ({c}) vs int c ({d})");

            //No data loss because float is smaller than double
            float f = 3.1415f;
            double g = f;
            //Cast has to be mentioned because double is more precise than float
            float h = (float)g;

            var convertExample = System.Convert.ToChar(1);
            Console.WriteLine(convertExample);

            int i = -255;
            uint j = (uint)i;
            Console.WriteLine($"when int -255 is explicitly converted to a uint, it give ({j})");

            //Boolean
            bool canFly = true;
            int k = System.Convert.ToInt32(canFly);
            Console.WriteLine($"bool ({canFly}) convert to int ({k})");

            double pi = Math.PI;
            var l = Math.Round(pi,2);
            Console.WriteLine($"Rounding pi to 2 demical places ({l})");
        }
    }
}
