using System;
using System.Linq;

namespace _12_TriFunction
{
    class TriFunktion
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, int> GetCharAsciiValueSum = sav => sav.Select(c => (int)c).Sum();

            Console.WriteLine(names
                .Where(n => GetCharAsciiValueSum(n) >= targetSum)
                .FirstOrDefault());
        }
    }
}