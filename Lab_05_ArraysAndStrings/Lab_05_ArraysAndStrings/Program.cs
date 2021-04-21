using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_05_ArraysAndStrings
{
    class Program
    {
        static void Main()
        {
            int[] intArray = { 1, 2, 3, 4 };
            char[] charArray = new char[4];

            charArray[0] = 'K';
            charArray[1] = 'h';
            charArray[2] = 'a';
            charArray[3] = 'n';

            Console.WriteLine(ArraySum(intArray));

            int[,] grid = new int[2, 3];
            grid[0, 0] = 1;
            grid[0, 1] = 2;

            int[,] grid2 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };

            //Jagged array
            string[][] animalsGrid = new string[2][];
            animalsGrid[0] = new string[4];
            animalsGrid[0][0] = "Cat";
            animalsGrid[0][1] = "Chicken";
            animalsGrid[0][2] = "Cow";
            animalsGrid[0][3] = "Sheep";
            animalsGrid[1] = new string[2] { "Parrot", "Dog" };

            //Lists
            var numbers = new List<string>();
            numbers.Add("One");
            numbers.Add("Two");
            numbers.Add("Three");
            numbers.Add("Four");

            numbers.Remove("Four");

            numbers.ForEach(x => Console.WriteLine(x));

            int[] arrayToList = new int[4];
            List<int> list = new List<int>(arrayToList);
            var list2 = new List<int>() { 1, 2, 3, 4 };

            //Strings
            string name = "  Uzair Khan  ";
            int length = name.Length;
            var uppercase = name.ToUpper();
            var trimName = name.Trim();
            var findChar = name.Contains("a");

            foreach (var item in name)
            {
                Console.WriteLine(item);
            }

            var fifthLetter = name[5];

            var allChar = name.ToCharArray();

            //Concatination
            string fName = "Uzair";
            string lName = "Khan";
            double score = 0.91;

            Console.WriteLine(fName + " " + lName + ", Score: " + score);
            Console.WriteLine($"{fName} {lName}, Score: {score}");
            Console.WriteLine($"{fName} {lName}, Score: {score:p0}");
            Console.WriteLine($"{fName} {lName}, Score: {score:f1}");

            //Parsing
            Console.WriteLine("How many trainees");
            var input = Console.ReadLine();
            var numTrainees = Int32.Parse(input);
            Console.WriteLine(numTrainees);

            bool sucess = Int32.TryParse(input, out numTrainees);

            if (sucess)
            {
                Console.WriteLine($"There are {numTrainees} trainees");
            }
            else
            {
                Console.WriteLine("Enter valid number");
                Main();
            }

            string[] split = name.Split(" ");
            Console.WriteLine(split);

            //String builder
            var sb = new StringBuilder("Hello world!");
            sb.AppendLine(" and Eng86");
            sb.Append("Hope you are having a nice day");
            Console.WriteLine(sb);

            var sb2 = new StringBuilder();
            sb2.AppendLine("Uzair Khan");
            Console.WriteLine(sb2);
            sb2.Replace("z", "m");
            Console.WriteLine(sb2);
            sb2.Remove(6, 4);
            Console.WriteLine(sb2);
        }

        public static int ArraySum(int[] intArray)
        {
            int sum = 0;

            foreach (var item in intArray)
            {
                sum += item;
            }

            return sum;
        }


    }
}
