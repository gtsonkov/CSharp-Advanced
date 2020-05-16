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

            int smallestElement = elements[0];

            Stack<int> stack = new Stack<int>(tokens[0]);

            for (int i = 0; i < tokens[0]; i++)
            {
                int elementToPush = elements[i];

                stack.Push(elementToPush);

                if (elementToPush < smallestElement)
                {
                    smallestElement = elementToPush;
                }
            }

            for (int i = 0; i < tokens[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Count==0)
            {
                smallestElement = 0;
            }

            if (stack.Contains(tokens[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(smallestElement);
            }
        }
    }
}