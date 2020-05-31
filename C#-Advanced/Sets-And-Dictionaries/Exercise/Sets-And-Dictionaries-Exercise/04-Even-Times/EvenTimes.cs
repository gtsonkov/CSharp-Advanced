using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Even_Times
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> collection = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string number = Console.ReadLine();
                if (collection.ContainsKey(number))
                {
                    collection[number]++;
                }
                else
                {
                    collection.Add(number, 1);
                }
            }

            var numbs = collection.Where(x => x.Value % 2 == 0);

            foreach (var t in numbs)
            {
                Console.WriteLine(t.Key);
            }
        }
    }
}