using System;

namespace Lab_07_Selections
{
    public class Program
    {
        static void Main(string[] args)
        {
            var number = 15;
            var result = "";

            if (number % 5 == 0)
            {
                result += "Uzair";

                if (number % 3 == 0)
                {
                    result += "Can";
                }
                else
                {
                    result += "Can't";
                }

            }else
            {
                result += "Khan";
            }
            Console.WriteLine(result);
        }

        public static string Grade(int mark)
        {
            if (mark < 0 || mark > 100)
                throw new Exception("Mark out of range");

            var grade = "Fail";

            if (mark >= 40)
            {
                grade = "Pass";

                if (mark >= 75)
                {
                    grade += " with Distinction";
                }
                else if (mark >= 60)
                {
                    grade += " with Merit";
                }
            }

            return grade;
        }

        public static void DaysOfWeek(int day)
        {
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thusday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Not valid");
                    break;
            }
        }

        public static string Prority(int level)
        {
            var code = "Code ";

            switch (level)
            {
                case 3:
                    code += "Red";
                    break;
                case 2:
                case 1:
                    code += "Amber";
                    break;
                case 0:
                    code += "Green";
                    break;
                default:
                    code += "Invalid";
                    break;
            }

            return code;
        }

        public static string Turnary(int mark) => mark >= 40 ? "Pass" : "Fail";
    }
}
