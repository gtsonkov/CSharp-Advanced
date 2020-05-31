using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Periodic_Table
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> mySet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split().ToArray();

                foreach (var e in elements)
                {
                    mySet.Add(e);
                }
            }

            Console.WriteLine(string.Join(" ",mySet.OrderBy(x=> x)));
        }
    }
}