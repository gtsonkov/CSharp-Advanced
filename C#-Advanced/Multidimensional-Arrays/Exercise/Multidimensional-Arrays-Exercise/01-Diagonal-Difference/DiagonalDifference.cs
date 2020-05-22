﻿using System;

namespace DiagonalDifference
{
    using System.Linq;
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int SumPrimary = 0;
            int SumSecondary = 0;
            for (int i = 0; i < size; i++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                SumPrimary +=(row[i]);
                SumSecondary +=(row[(size - 1) - i]);
            }
            Console.WriteLine(Math.Abs(SumPrimary-SumSecondary));
        }
    }
}