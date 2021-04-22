using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseWordOrder
{
    public class WordReverser
    {

        public static string ReverseWords(string input)
        {
            //Method should reverse the order of a string
            List<string> list = new List<string>(input.Split(" "));
            string output = "";
            for(int i = list.Count - 1; i >= 0; i--)
            {
                output += list[i] + " ";
            }
            return output.Trim();
        }

    }
}
