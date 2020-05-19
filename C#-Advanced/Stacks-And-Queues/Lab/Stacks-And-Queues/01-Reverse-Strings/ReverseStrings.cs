using System;
using System.Collections.Generic;

namespace _01_Reverse_Strings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> charSteack = new Stack<char>(input);

            while (charSteack.Count > 0)
            {
                Console.Write(charSteack.Pop());
            }

            Console.WriteLine();
        }
    }
}