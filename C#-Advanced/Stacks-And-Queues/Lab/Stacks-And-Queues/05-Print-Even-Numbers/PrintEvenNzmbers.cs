using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Print_Even_Numbers
{
    class PrintEvenNzmbers
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x=> x%2 == 0)
                .ToArray();

            Queue<int> queue = new Queue<int>(input);

            Console.WriteLine(string.Join(", ", input));
        }
    }
}