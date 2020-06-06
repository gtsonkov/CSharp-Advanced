using System;
using System.IO;

namespace _02_Line_Numbers
{
    class LineNumers
    {
        static void Main(string[] args)
        {
            string readPath = Path.Combine("Data", "text.txt");
            string writePath = Path.Combine("Data", "output.txt");

            var lines = File.ReadAllLines(readPath);

            string[] buffer = new string[lines.Length];

            int counter = 1;

            foreach (var line in lines)
            {
                int lettersCount = 0;
                int punctuationCount = 0;

                foreach (var ch in line)
                {
                    if (char.IsLetter(ch))
                    {
                        lettersCount++;
                    }
                    else if (char.IsPunctuation(ch))
                    {
                        punctuationCount++;
                    }
                }
                buffer[counter - 1] = ($"Line {counter}:{line} ({lettersCount})({punctuationCount})");
                counter++;
            }

            File.WriteAllLines(writePath, buffer);
        }
    }
}