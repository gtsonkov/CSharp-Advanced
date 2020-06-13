using System;
using System.Linq;

namespace _02_Sum_Numbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(input.Length);
            Console.WriteLine(input.Sum());
        }
    }
}