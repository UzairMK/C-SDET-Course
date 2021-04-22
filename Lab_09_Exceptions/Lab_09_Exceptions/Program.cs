using System;

namespace Lab_09_Exceptions
{
    public class Program
    {
        public static string[] animals = { "Dog", "Cat", "Parrot", "Monke" };

        static void Main()
        {
            try
            {
                animals[4] = "Deer";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("This is in the finally section of the try-catch block");
            }

            //Exception heiracy
            try
            {
                var x = 10;
                var y = 0;
                var calc = x / y;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("This is in the finally section of the try-catch block");
            }

            //Throwing exceptions
            try
            {
                animals[4] = "Deer";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void AddAnimal(int pos, string animal)
        {
            if (pos < 0 || pos >= animals.Length)
                throw new IndexOutOfRangeException("Animal not allowed here");
            animals[pos] = animal;
        }
    }
}
