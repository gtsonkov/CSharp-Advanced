using System;
using System.Linq;

namespace _02_SquareMatrix
{
    class SquareInMatrix
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int row = size[0];
            int col = size[1];

            string[,] matrix = new string[row, col];

            for (int i = 0; i < row; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int count = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    string comapre = matrix[i, j];

                    if ((comapre == matrix[i + 1, j + 1]) && (comapre == matrix[i, j + 1]) && (comapre == matrix[i + 1, j]))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}