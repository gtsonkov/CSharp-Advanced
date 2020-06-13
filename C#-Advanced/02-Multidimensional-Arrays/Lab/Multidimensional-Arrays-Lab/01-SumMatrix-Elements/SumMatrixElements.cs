using System;
using System.Linq;

namespace SumMatrixElements
{
    class SumMatrixElements
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];
            int sum = 0;
            for (int i = 0; i < dimensions[0]; i++)
            {
                int[] NumbersInput = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix[i, j] = NumbersInput[j];
                    sum += matrix[i, j];
                }
            }
            Console.WriteLine(dimensions[0]); // Number of Rows
            Console.WriteLine(dimensions[1]); // Number of Cols
            Console.WriteLine(sum); // Sum of Elements
        }
    }
}