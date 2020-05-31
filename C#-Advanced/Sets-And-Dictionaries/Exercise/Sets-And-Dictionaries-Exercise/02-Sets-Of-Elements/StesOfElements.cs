using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Sets_Of_Elements
{
    class StesOfElements
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            HashSet<int> hashset1 = new HashSet<int>();
            HashSet<int> hashset2 = new HashSet<int>();
            for (int i = 0; i < nm[0]; i++)
            {
                int input = int.Parse(Console.ReadLine());
                hashset1.Add(input);
            }
            for (int i = 0; i < nm[1]; i++)
            {
                int input = int.Parse(Console.ReadLine());
                hashset2.Add(input);
            }

            hashset1.IntersectWith(hashset2);

            Console.WriteLine(string.Join(" ",hashset1));
        }
    }
}