using System;
using System.Linq;

namespace _01_Action_Point
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split()
                .ToArray();

            Action<string[]> printNames = a =>
            Console.WriteLine(string
            .Join(Environment.NewLine, a));

            printNames(names);
        }
    }
}