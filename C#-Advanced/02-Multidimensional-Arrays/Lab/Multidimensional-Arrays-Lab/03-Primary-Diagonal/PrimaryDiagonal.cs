using System;
using System.Linq;

namespace _03_Primary_Diagonal
{
    class PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            int positionOnDiagonal = -1;
            int sumOfDiagonalParts = 0;

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                positionOnDiagonal++;

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];

                    if (j == positionOnDiagonal)
                    {
                        sumOfDiagonalParts += input[j];
                    }
                }
            }

            Console.WriteLine(sumOfDiagonalParts);
        }
    }
}