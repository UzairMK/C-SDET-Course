using System;

namespace Lab_01_Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // PascalCase -- used for Classes and Methods
            // camelCase -- used for variables
            // _camelCase -- used for private variables
            // snake_case
            // kabab-case

            int x = 100;
            x += 10;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                x += 1;
            }

            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
        }
    }
}
