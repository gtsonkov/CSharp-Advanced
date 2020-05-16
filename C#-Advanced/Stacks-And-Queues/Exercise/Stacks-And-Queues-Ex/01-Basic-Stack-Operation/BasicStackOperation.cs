using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Basic_Stack_Operation
{
    public class BasicStackOperation
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(tokens[0]);

            for (int i = 0; i < tokens[0]; i++)
            {
                int elementToPush = elements[i];

                stack.Push(elementToPush);
            }

            for (int i = 0; i < tokens[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(tokens[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallestElement = 0;

                if (stack.Count>0)
                {
                    smallestElement = stack.Pop();

                    while (stack.Count > 0)
                    {
                        int currElement = stack.Pop();
                        if (currElement < smallestElement)
                        {
                            smallestElement = currElement;
                        }
                    }
                }

                Console.WriteLine(smallestElement);
            }
        }
    }
}