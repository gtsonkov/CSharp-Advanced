using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Minimum_And_Maximum_Element
{
    class MinimumAndMaximumElement
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < count; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = tokens[0];

                switch (command)
                {
                    case 1:
                        stack.Push(tokens[1]);
                        break;

                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;

                    case 3:
                        if (stack.Count>0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;

                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(String.Join(", ",stack));
        }
    }
}