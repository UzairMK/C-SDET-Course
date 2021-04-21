
using System.Collections.Generic;

namespace CollectionsExercisesLib
{
    public class CollectionsExercises
    {
        /* removes and returns the next num entries in the queue, as a comma separated string */
        public static string NextInQueue(int num, Queue<string> queue)
        {
            string result = "";

            for (int i = 0; i < num; i++)
            {
                if (i == num - 1 || queue.Count == 1)
                {
                    result += queue.Dequeue();
                    break;
                }

                result += queue.Dequeue() + ", ";
            }

            return result;
        }

        /* uses a Stack to create and return array of ints in reverse order to the one supplied */
        public static int[] Reverse(int[] original)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i <= original.GetUpperBound(0); i++)
            {
                stack.Push(original[i]);
            }

            return stack.ToArray();
        }
        // using a Dictionary, counts and returns (as a string) the occurence of the digits 0-9 in the given string
        public static string CountDigits(string input)
        {
            Dictionary<char, int> digitCount = new Dictionary<char, int>();
            List<char> validChar = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            foreach (char c in input)
            {
                if (!validChar.Contains(c))
                    continue;

                if (digitCount.ContainsKey(c))
                {
                    digitCount[c] += 1;
                }
                else
                {
                    digitCount[c] = 1;
                }
            }

            string result = "";

            foreach (var dict in digitCount)
            {
                result += $"[{dict.Key}, {dict.Value}]";
            }

            return result;
        }
    }
}