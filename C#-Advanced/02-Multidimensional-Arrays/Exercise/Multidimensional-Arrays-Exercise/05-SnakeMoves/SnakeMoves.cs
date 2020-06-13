using System;
using System.Linq;

namespace _05_SnakeMoves
{
    public class SnakeMoves
    {
        public static void Main()
        {
            int[] sizeMatrix = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = sizeMatrix[0];
            int column = sizeMatrix[1];

            char[,] matrix = new char[rows, column];
            char[] snake = Console.ReadLine().ToCharArray();
            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < column; col++)
                    {
                        matrix[row, col] = snake[index];
                        index++;

                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                    }
                }

                else
                {
                    for (int col = column - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[index];
                        index++;

                        if (index == (snake.Length))
                        {
                            index = 0;
                        }
                    }
                }
            }

            PrintMatrix(matrix);
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}