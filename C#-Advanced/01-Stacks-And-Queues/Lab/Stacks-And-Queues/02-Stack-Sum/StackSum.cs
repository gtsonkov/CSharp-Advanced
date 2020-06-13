using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Stack_Sum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            int[] initialInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(initialInput);
            string[] command = Console.ReadLine()
                .ToLower()
                .Split()
                .ToArray();

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "add":

                        int first = int.Parse(command[1]);
                        int second = int.Parse(command[2]);
                        stack.Push(first);
                        stack.Push(second);

                        break;

                    case "remove":
                        int numsToRemove = int.Parse(command[1]);

                        if (stack.Count >= numsToRemove)
                        {
                            for (int i = 0; i < numsToRemove; i++)
                            {
                                stack.Pop();
                            }
                        }

                        break;
                }

                command = Console.ReadLine()
                .ToLower()
                .Split()
                .ToArray();

            }

            int sum = 0;

            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine("Sum: " + sum);

        }
    }
}