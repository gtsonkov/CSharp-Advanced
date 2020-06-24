using System;
using System.Linq;

namespace _06_Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            var result = input.Where(x => x % n != 0).Reverse();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}