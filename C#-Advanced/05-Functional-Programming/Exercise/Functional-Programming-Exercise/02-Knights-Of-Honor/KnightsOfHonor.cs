using System;
using System.Linq;

namespace _02_Knights_Of_Honor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split()
                .Select(x => $"Sir {x}").ToArray();

            Action<string[]> printNames = a =>
            Console.WriteLine(string
            .Join(Environment.NewLine, a));

            printNames(names);
        }
    }
}