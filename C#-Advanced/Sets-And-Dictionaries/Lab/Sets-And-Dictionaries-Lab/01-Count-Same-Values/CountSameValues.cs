using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Count_Same_Values
{
    class CountSameValues
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            Dictionary<string, int> counter = new Dictionary<string, int>();

            foreach (var numb in input)
            {
                if (counter.ContainsKey(numb))
                {
                    counter[numb] ++;
                }
                else
                {
                    counter.Add(numb, 1);
                }
            }

            foreach (var p in counter)
            {
                Console.WriteLine(p.Key + " - " + p.Value + " times");
            }
        }
    }
}