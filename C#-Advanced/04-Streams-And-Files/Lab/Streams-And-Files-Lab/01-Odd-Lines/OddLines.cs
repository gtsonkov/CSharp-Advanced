using System;
using System.IO;

namespace _01_Odd_Lines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("Data", "input.txt");
            string dest = Path.Combine("Data", "output.txt");

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (TextReader textReader = new StreamReader(file))
                {
                    using (FileStream destFile = new FileStream(dest, FileMode.Create))
                    {
                        using (TextWriter textWriter = new StreamWriter(destFile))
                        {
                            string line = textReader.ReadLine();
                            int count = 0;
                            while (line != null)
                            {
                                if (count % 2 != 0)
                                {
                                    textWriter.WriteLine(line);
                                }

                                count++;

                                line = textReader.ReadLine();
                            }
                        }
                    }
                }
            }
        }
    }
}