using System;
using System.Linq;

namespace _02_Sum_Matrix_Columns
{
    class SumMatrixColumns
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            int[] sumColumns = new int[dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                int[] NumbersInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix[i, j] = NumbersInput[j];
                    sumColumns[j] += matrix[i, j];
                }
            }

            foreach (var colSum in sumColumns)
            {
                Console.WriteLine(colSum);
            }
        }
    }
}