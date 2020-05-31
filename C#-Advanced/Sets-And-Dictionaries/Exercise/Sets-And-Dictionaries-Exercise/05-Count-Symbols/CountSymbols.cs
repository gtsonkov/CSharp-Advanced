using System;
using System.Collections.Generic;

namespace _05_Count_Symbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            foreach (var ch in input)
            {
                if (chars.ContainsKey(ch))
                {
                    chars[ch]++;
                }
                else
                {
                    chars.Add(ch, 1);
                }
            }
            foreach (var ch in chars)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}