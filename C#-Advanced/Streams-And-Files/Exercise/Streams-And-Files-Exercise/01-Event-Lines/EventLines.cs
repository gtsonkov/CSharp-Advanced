using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01_Event_Lines
{
    class EventLines
    {
        static void Main(string[] args)
        {
            string readPath = Path.Combine("Data", "text.txt");
            string writePath = Path.Combine("Data", "output.txt");

            using (var sr = new StreamReader(readPath))
            {
                using (var sw = new StreamWriter(writePath))
                {
                    string currLine = sr.ReadLine();

                    int count = 0;

                    while (currLine != null)
                    {
                        if (count % 2 == 0)
                        {
                            var readedData = currLine.Split(" ").ToArray();
                            Regex pattern = new Regex(@"[-]|[;]|[,]|[.]|[!]|[?]");
                            currLine = pattern.Replace(currLine, "@");

                            string[] result = currLine.Split(" ").ToArray();

                            sw.WriteLine(string.Join(" ",result.Reverse()));
                        }

                        count++;
                        currLine = sr.ReadLine();
                    }
                }
            }
        }
    }
}