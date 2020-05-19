using System;
using System.Collections.Generic;

namespace _04_Matching_Brackets
{
    class MatchingBrackets
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char value = input[i];

                if (value == '(')
                {
                    stack.Push(i);
                }
                else if (value == ')')
                {
                    int index = stack.Pop();
                    string part = input.Substring(index, i - index + 1);

                    Console.WriteLine(part);
                }
            }
        }
    }
}