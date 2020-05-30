using System;

namespace _04_MatrixSuffling
{

    namespace Matrix_shuffling
    {
        using System.Linq;
        class Matrixshuffling
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
                    string[] input = Console.ReadLine()
                        .Split()
                        .ToArray();
                    for (int j = 0; j < col; j++)
                    {
                        matrix[i, j] = input[j];
                    }
                }

                while (true)
                {
                    string[] command = Console.ReadLine().Split().ToArray();
                    if (command[0] == "END")
                    {
                        return;
                    }

                    if (!(command[0] == "swap") || !(command.Length == 5))
                    {
                        PrintInavlidCommand();
                    }
                    else
                    {
                        int row1 = int.Parse(command[1]);
                        int col1 = int.Parse(command[2]);
                        int row2 = int.Parse(command[3]);
                        int col2 = int.Parse(command[4]);

                        try
                        {
                            string temp = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = temp;
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    Console.Write(matrix[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                        }

                        catch (Exception)
                        {

                            PrintInavlidCommand();
                        }
                    }
                }
            }

            private static void PrintInavlidCommand()
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
