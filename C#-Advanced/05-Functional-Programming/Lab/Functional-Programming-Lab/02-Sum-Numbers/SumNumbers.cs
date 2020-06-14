using System;
using System.Linq;

namespace _02_Sum_Numbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            //Variant 1

            //int[] input = Console.ReadLine()
            //    .Split(", ")
            //    .Select(int.Parse)
            //    .ToArray();
            //Console.WriteLine(input.Length);
            //Console.WriteLine(input.Sum());

            //Variant 2
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(e =>
                {
                    int result = int.Parse(e);
                    return result;
                })
                .ToArray();
            Console.WriteLine(input.Length);
            Console.WriteLine(input.Sum());
        }
    }
}