using System;

namespace RemoveExclamation
{
    public class Remove
    {
        public static string RemoveLastExclamationMark(string input)
        {
            //Remove a exclamation mark from the end of string.
            if (input[input.Length-1] == '!')
                input = input.Remove(input.Length - 1);
            return input;
        }
    }
}
