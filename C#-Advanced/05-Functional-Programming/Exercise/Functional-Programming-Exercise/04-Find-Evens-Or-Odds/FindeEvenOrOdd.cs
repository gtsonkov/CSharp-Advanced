using System;
using System.Linq;

namespace _04_Find_Evens_Or_Odds
{
    class FindeEvenOrOdd
    {
        static void Main(string[] args)
        {
            int[] limits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Predicate<int> isEven = x => (x % 2 == 0);

            string token = Console.ReadLine();
            for (int i = limits[0]; i <= limits[1]; i++)
            {
                if (token == "even")
                {
                    if (isEven(i))
                    {
                        Console.Write(i + " ");
                    }
                }
                else
                {
                    if (!isEven(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}