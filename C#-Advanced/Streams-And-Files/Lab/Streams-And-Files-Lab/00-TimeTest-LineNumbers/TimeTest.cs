using System;
using System.Diagnostics;
using System.IO;

namespace _00_TimeTest_LineNumbers
{
    class TimeTest
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("Data", "input.txt");
            string dest = Path.Combine("Data", "output.txt");

            var timer = new Stopwatch();

            timer.Start();

            var lines = File.ReadAllLines(path);

            string[] sb = new string[lines.Length];

            int counter = 1;

            foreach (var line in lines)
            {
                sb[counter - 1] = ($"{counter}. " + line);
                counter++;
            }

            File.WriteAllLines(dest, sb);

            Console.WriteLine(timer.Elapsed);
        }
    }
}
