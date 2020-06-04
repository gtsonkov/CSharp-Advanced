using System;
using System.IO;
using System.Text;

namespace _02_Line_Numbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("Data","input.txt");
            string dest = Path.Combine("Data", "output.txt");

            

            var lines = File.ReadAllLines(path);

            string[] sb = new string[lines.Length];

            int counter = 1;

            foreach (var line in lines)
            {
                sb[counter-1] = ($"{counter}. " + line);
                counter++;
            }

            File.WriteAllLines(dest, sb);
        }
    }
}