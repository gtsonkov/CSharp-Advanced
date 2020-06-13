using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03_Word_Count
{
    class WordCount
    {
        static void Main(string[] args)
        {
            string textPath = Path.Combine("Data", "input.txt");
            string wordsPath = Path.Combine("Data", "words.txt");
            string destPath = Path.Combine("Data", "output.txt");

            var text = File.ReadAllText(textPath).Split(new[] { '.', ' ', ',', '-', '?', '!', ':', ';'},
                    StringSplitOptions.RemoveEmptyEntries).ToArray();

            var wordsToSearch = File.ReadAllText(wordsPath).Split().ToArray();

            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var w in wordsToSearch)
            {
                words.Add(w, 0);
            }

            foreach (var t in wordsToSearch)
            {
                foreach (var w in text)
                {
                    if (w.ToLower() == (t.ToLower()))
                    {
                        words[t]++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var w in words.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine(w.Key + "-" + w.Value );
                sb.AppendLine(w.Key + "-" + w.Value);
            }

            File.WriteAllText(destPath,sb.ToString());
        }
    }
}