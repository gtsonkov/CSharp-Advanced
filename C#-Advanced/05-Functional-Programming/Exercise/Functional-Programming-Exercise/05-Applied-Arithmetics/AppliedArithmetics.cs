using System;
using System.Linq;

namespace _05_Applied_Arithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Func<int, string, int> Manipulate = delegate (int x, string command)
            {
                  switch (command)
                  {
                      case "add":
                          return (x + 1);
                      case "multiply":
                          return (x * 2);
                      case "subtract":
                          return (x - 1);
                  }

                  return 0;
            };

            while (command != "end")
            {
                if (command != "print")
                {
                   input = input.Select(x => Manipulate(x, command)).ToArray();
                }
                else
                {
                    Console.WriteLine(string.Join(" ", input));
                }

                command = Console.ReadLine();
            }

        }
    }
}