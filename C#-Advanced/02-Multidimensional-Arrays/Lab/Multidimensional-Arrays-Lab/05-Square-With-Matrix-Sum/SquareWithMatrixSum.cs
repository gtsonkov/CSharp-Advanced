using System;
using System.Linq;

namespace _05_Square_With_Matrix_Sum
{
    class SquareWithMatrixSum
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int[] maxSquare = new int[3]; //Row,Col,Sum

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                int[] NumbersInput = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix[i, j] = NumbersInput[j];
                }
            }

            for (int i = 0; i < dimensions[0]-1; i++)
            {
                if (i == 0) // Ste the firsone and compare with them
                {
                    maxSquare[0] = 0;
                    maxSquare[1] = 0;
                    maxSquare[2] = (matrix[0, 0] + matrix[0, 1] + matrix[1, 0] + matrix[1, 1]);
                }

                if (dimensions[1] % 2 == 0)
                {
                    for (int j = 0; j < dimensions[1] - 1; j ++)
                    {
                        CompareSquares(i,j,maxSquare,matrix);
                    }
                }

                else
                {
                    for (int j = 0; j < dimensions[1] -1; j ++)
                    {
                        if (j == dimensions[1] -1)
                        {
                            CompareSquares(i, j-1, maxSquare, matrix);
                            break;
                        }

                        CompareSquares(i, j, maxSquare, matrix);
                    }
                }
                
            }

            int x = maxSquare[0];
            int y = maxSquare[1];
            Console.WriteLine(matrix[x,y] + " " + matrix[x,y+1]);
            Console.WriteLine(matrix[x+1,y] + " " + matrix[x+1,y+1]);
            Console.WriteLine(maxSquare[2]);
        }

        private static void CompareSquares(int i, int j, int[] maxSquare, int[,] matrix) // use reference to maxSquare to save the result
        {
            int currentSum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];

            if (currentSum > maxSquare[2])
            {
                maxSquare[0] = i;
                maxSquare[1] = j;
                maxSquare[2] = currentSum;
            }
        }
    }
}