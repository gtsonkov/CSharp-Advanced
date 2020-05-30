using System;
using System.Linq;

namespace MaximalSum
{
    public class MaximalSum
    {
        public static void Main()
        {
            int[] sizeValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = sizeValues[0];
            int column = sizeValues[1];

            int[,] matrix = new int[rows, column];
            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < column; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int maxSum = int.MinValue;
            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < column - 2; col++)
                {
                    int currentFirstUpValue = matrix[row, col];
                    int currentMiddleUpValue = matrix[row, col + 1];
                    int currentRightUpValue = matrix[row, col + 2];

                    int currentFirstMiddleValue = matrix[row + 1, col];
                    int currentMiddleOfMiddleValue = matrix[row + 1, col + 1];
                    int currentRightMiddleValue = matrix[row + 1, col + 2];

                    int currentFirstDownValue = matrix[row + 2, col];
                    int currentMiddleValue = matrix[row + 2, col + 1];
                    int currentRightDownValue = matrix[row + 2, col + 2];

                    int sum = currentFirstUpValue + currentMiddleUpValue
                        + currentRightUpValue + currentFirstMiddleValue + currentMiddleOfMiddleValue
                        + currentRightMiddleValue + currentFirstDownValue + currentMiddleValue
                        + currentRightDownValue;

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = currentRow; row <= currentRow + 2; row++)
            {
                for (int col = currentCol; col <= currentCol + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
