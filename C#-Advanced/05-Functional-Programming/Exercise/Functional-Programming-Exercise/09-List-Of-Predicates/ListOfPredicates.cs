using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_List_Of_Predicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> range = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                range.Add(i);
            }

            foreach (var num in range)
            {
                bool disible = true;

                foreach (var divider in dividers)
                {
                    if ((num % divider) != 0)
                    {
                        disible = false;
                        break;
                    }
                }
                if (disible)
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}