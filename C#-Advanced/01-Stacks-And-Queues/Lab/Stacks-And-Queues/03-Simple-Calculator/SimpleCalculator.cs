using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Simple_Calculator
{
    public class SimpleCalculator
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ");
            Stack<string> stack = new Stack<string>(input.Reverse());
            
            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string opr = stack.Pop();
                int second = int.Parse(stack.Pop());

                switch (opr)
                {
                    case "+":
                        stack.Push((first + second).ToString());
                        break;

                    case "-":
                        stack.Push((first - second).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}