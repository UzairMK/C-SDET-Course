//#define TEST

using System;
using System.IO;
using System.Diagnostics;

namespace Files_Encoding_Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console Logging
            Console.WriteLine($"This is logged at {DateTime.Now}");

            //Trace Logging
            var twtl = new TextWriterTraceListener(File.Create("TraceOutput.txt"));

            Trace.Listeners.Add(twtl);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i);
                Debug.WriteLine($"Debug - The value of i is {i}");
                Trace.WriteLine($"Trace - The value of i is {i}");
                Debug.WriteLineIf(i == 2, $"\nReached max value of i: {i} at {DateTime.Now}");
                //Trace.Assert(i > 0, $"i is not greater than zero {i}");
            }
            Trace.Flush();

            //Comditional compiling
            Console.WriteLine("Starting app.");
#if DEBUG
            Console.WriteLine("Debug code.");
#if TEST
            Console.WriteLine("Test code.");
#endif
#endif
            Console.WriteLine("Finishing app.");

            //Encoding
            string input;
            bool @continue;

            do
            {

                Console.WriteLine("Please input string");
                input = Console.ReadLine();
                foreach (var c in input)
                {
                    Console.WriteLine(System.Convert.ToInt32(c));
                }
                Console.WriteLine("Input 'yes' if you want to continue, else press 'enter' to exit");
                @continue = Console.ReadLine().ToLower() == "yes" ? true : false;
            } while (@continue);


            //Stream reader and writer
            string path = "LiveForever.txt";

            StreamWriter sw = File.AppendText(path);
            sw.WriteLine("Live Forever");
            sw.Close();

            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
