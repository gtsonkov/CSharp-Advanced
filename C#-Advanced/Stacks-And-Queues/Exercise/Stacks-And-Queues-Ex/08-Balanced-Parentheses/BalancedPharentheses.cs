using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Balanced_Parentheses
{
    class BalancedPharentheses
    {
        static char[] _openBrackets = new char[] { '[', '{', '(' };
        static char[] _closeBrackets = new char[] { ']', '}', ')' };

        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToArray();

            if (input.Count() == 0 || !(input.Count() % 2 == 0) || (!IsOpenBracked(input[0])))
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> openBrackets = new Stack<char>();

            foreach (var br in input)
            {
                if (IsOpenBracked(br))
                {
                    openBrackets.Push(br);
                }
                else
                {
                    if (openBrackets.Count == 0 || !(MachBrackets(openBrackets.Pop(),br)))
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if (openBrackets.Count>0)
            {
                Console.WriteLine("NO");
                return;
            }

            Console.WriteLine("YES");
        }

        private static bool MachBrackets(char br1, char br2)
        {
            int index1 = Array.IndexOf(_openBrackets, br1);
            int index2 = Array.IndexOf(_closeBrackets, br2);

            return index1 == index2;
        }

        private static bool IsOpenBracked(char br)
        {
            return _openBrackets.Contains(br);
        }
    }
}