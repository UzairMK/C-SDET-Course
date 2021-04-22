using System;
using System.Diagnostics;

namespace Lab_10_DataTypes_Part2
{
    class Program
    {
        readonly string fName;
        const int dozen = 12;

        public Program()
        {
            fName = "Uzair";
        }

        static void Main(string[] args)
        {
            //Date
            var d1 = new DateTime();
            var d2 = DateTime.Today;

            var d3 = new DateTime(1997, 05, 11, 10, 5, 12);
            var d4 = d3.AddDays(365);
            var d5 = d4.AddMonths(12);

            var age = d2 - d3;
            Console.WriteLine($"You are {age.Days/365} years old");

            var output1 = DateTime.Now.ToString("dd/MM/yyyy");
            var output2 = DateTime.Now.ToString("yyyy-MMM-ddd HH:mm:ss");
            Console.WriteLine(output1);
            Console.WriteLine(output2);

            //Time span and Ticks
            var timeSpan = new TimeSpan(1,0,0); //1 hour
            var in1Hour = DateTime.Now + timeSpan;
            Console.WriteLine(in1Hour);

            //Stopwatch
            var sw = new Stopwatch();
            sw.Start();

            int total = 0;

            for (int i = 0; i < 10; i++)
            {
                total += 1;
            }

            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}");
            Console.WriteLine($"Elapsed ms: {sw.ElapsedMilliseconds}");
            Console.WriteLine($"Elapsed ticks: {sw.ElapsedTicks}");

            //Enums
            Suit heartsSuit = Suit.HEARTS;
            Suit clubsSuit = (Suit)29;
            int diamondsSuit = (int)Suit.DIAMONDS;
            Console.WriteLine(heartsSuit);
            Console.WriteLine(clubsSuit);
            Console.WriteLine(diamondsSuit);

            //Default
            int defaultInt;
            string defaultString;
            bool defaultBool;
            char defaultChar;
            float defaultFloat;
            DateTime defaultDateTime;
            int[] defaultArray;

            //Nullable types
            int? hasPassed = null;

            if (hasPassed.HasValue)
            {
                Console.WriteLine("hasPassed has a value");
            }
            else
            {
                Console.WriteLine("hasPassed does not have a value");
            }

            int? nullableScore = null;
            int score1 = nullableScore ?? -9999;
            int score2 = nullableScore.GetValueOrDefault(-1);
            int score3 = nullableScore.GetValueOrDefault();

            //const, readonly and dynamic
            const int minAge = 18;
            dynamic item = 100;
            Console.WriteLine($"Adding 10 to {item} gives {item + 10}");
            item = "Hello";
            Console.WriteLine($"Adding 10 to {item} gives {item + 10}");

            //Random
            var rng = new Random(); //Seeds with current time if none given
            var myRNG = new Random(3);
            var numberBetween1And10 = myRNG.Next(1, 11);

            var dice1 = rng.Next(6);
            var dice2 = rng.Next(6);
            var dice3 = rng.Next(6);

            Console.WriteLine($"Dice 1 = {dice1}, Dice 2 = {dice2}, Dice 3 = {dice3}");
        }

        public enum Suit {HEARTS =27, DIAMONDS, CLUBS, SPADES};

        public static string Suits(Suit suit)
        {
            switch (suit)
            {
                case Suit.HEARTS:
                    return "Hearts";
                case Suit.DIAMONDS:
                    return "Diamonds";
                case Suit.CLUBS:
                    return "Clubs";
                case Suit.SPADES:
                    return "Spades";
                default:
                    return "Oops";
            }
        }
    }
}
