using System;

namespace Lab_04_Methods_UnitTesting
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoThis();

            var int_return = Return100();
            Console.WriteLine(int_return);

            if (int_return == SquareNumber(10, "Should output 100"))
            {
                Console.WriteLine("int_return equals 10 squared");
            }

            Console.WriteLine(OrderPizza(tuna: true, mushroom: true, pineapple: false));

            var number = 1;
            AddOne(ref number);
            Console.WriteLine($"Used ref in a method to add one to a local variable \"number ({number})\" to get {number}");

            UsingOut(out int z);
            Console.WriteLine($"Used the UsingOut to get variable z ({z}) and when z is put in the SquareNumber method, we get {SquareNumber(z)}");

            var myTuple = ("Uzair", "Khan", 23);
            (string,string,int) myTuple2 = ("Uzair", "Khan", 23);
            (string fName,string lName,int age) myTuple3 = ("Uzair", "Khan", 23);
            var myTuple4 = (fName:"Uzair", lName:"Khan", age:23);

            Console.WriteLine(myTuple);
            Console.WriteLine(myTuple2.Item2);
            Console.WriteLine(myTuple3.age);
            Console.WriteLine(myTuple4.fName);

            var (TMstring, TMint) = MakeTuple("Hi", 8);
            Console.WriteLine($"Made MakeTuple return to variables TMstring ({TMstring}) and TMint ({TMint})");

            var tripleCalcOut = TripleCalc(2, 2, 2, out int sum);
            var tripleCalcTuple = TripleCalc(2, 2, 2);
            Console.WriteLine($"tripleCalcOut = {tripleCalcOut}, with sum = {sum} \ntripleCalcTuple.sum = {tripleCalcTuple.sum} and tripleCalcTuple.product = {tripleCalcTuple.product}");
        }

        public static void DoThis()
        {
            Console.WriteLine("DoThis method run");
        }

        public static int Return100()
        {
            Console.WriteLine("Return100 method run");
            return 100;
        }

        public static int SquareNumber(int x, string y = "No string input in SquareNumber")
        {
            Console.WriteLine(y);
            return x * x;
        }

        public static string OrderPizza(bool pineapple, bool tuna, bool mushroom)
        {
            string pizza = "Your pizza will have:";
            if (pineapple)
                pizza += " pineapple";
            if (tuna)
                pizza += " tuna";
            if (mushroom)
                pizza += " mushrooms";
            return pizza;
        }

        public static void AddOne(ref int x)
        {
            x++;
        }

        public static void UsingOut(out int z)
        {
            z = 14;
        }

        public static (string x, int y) MakeTuple(string x, int y)
        {
            return (x, y);
        }

        public static int TripleCalc(int a, int b, int c, out int sum)
        {
            sum = a + b + c;
            return a * b * c;
        }

        public static (int sum, int product) TripleCalc(int a, int b, int c)
        {
            return (a + b + c, a * b * c);
        }
    }
}
