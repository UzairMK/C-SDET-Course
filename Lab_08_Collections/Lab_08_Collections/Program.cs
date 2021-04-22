using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_08_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add("Hello");
            arrayList.Add(1);
            arrayList.Add('c');

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            List<int> intList = new List<int>() { 1, 2, 3, 4 };

            var x = intList[1];
            intList.Remove(1);
            Console.WriteLine(CombineToString(intList));

            //List task
            List<int> task = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(CombineToString(task));
            task.Add(6);
            task.Add(7);
            task.Add(8);
            task[4] = 2;
            task.Reverse();
            task.RemoveAt(3);
            Console.WriteLine(CombineToString(task));
            task.Sort();
            Console.WriteLine(CombineToString(task));

            //Queue
            Queue<string> stringQueue = new Queue<string>();
            stringQueue.Enqueue("Dog");
            stringQueue.Enqueue("Cat");

            Console.WriteLine("First in queue: " + stringQueue.Peek());
            Console.WriteLine("Queue contains Cat?: " + stringQueue.Contains("Cat"));
            Console.WriteLine("Taking this out of queue: " + stringQueue.Dequeue());
            Console.WriteLine("First in queue: " + stringQueue.Peek());

            //Stack
            Stack<string> stringStack = new Stack<string>();
            stringStack.Push("Yellow");
            stringStack.Push("Red");

            Console.WriteLine("Last in stack: " + stringStack.Peek());
            Console.WriteLine("Stack contains Red?: " + stringStack.Contains("Red"));
            Console.WriteLine("Taking this from top of stack: " + stringStack.Pop());
            Console.WriteLine("Last in stack: " + stringStack.Peek());

            //HashSet
            List<string> eng86List = new List<string>() {"Uzair", "Nish", "Eric", "Eric", "Liam", "Callum" };
            HashSet<string> eng86HashSet = new HashSet<string>(eng86List);
            Console.WriteLine(CombineToString(eng86HashSet));

            //Dictionary
            Dictionary<string, int> numberOfTrainee = new Dictionary<string, int>() { { "Bob", 4 }, { "Sally", 2 } };
            numberOfTrainee.Add("Nish", 8);
            numberOfTrainee.Add("Cathy", 6);
            numberOfTrainee.Add("Git", 9);

            foreach (var item in numberOfTrainee)
            {
                Console.WriteLine($"Trainer, {item.Key}, has {item.Value} trainees");
            }
        }

        public static string CombineToString(IEnumerable collection)
        {
            string output = "";
            foreach (var item in collection)
            {
                output += item + "   ";
            }
            return output;
        }
    }
}
