using System;
using System.Linq;

namespace _06_JaggedArrayManipilator
{
    class JaggedArrayManipulator
    {
        static void Main()
        {
            int totalRows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[totalRows][];

            for (int row = 0; row < totalRows; row++)
            {
                double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

                jaggedArray[row] = new double[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    jaggedArray[row][col] = input[col];
                }
            }

            AnalyzingJaggedArray(jaggedArray);

            while (true)
            {
                string line = Console.ReadLine();
                string[] elements = line.Split();
                string command = elements[0];

                if (command == "End")
                {
                    break;
                }

                int row = int.Parse(elements[1]);
                int column = int.Parse(elements[2]);
                int value = int.Parse(elements[3]);

                if (!IsRange(row, column, jaggedArray))
                {
                    continue;
                }

                if (command == "Add")
                {
                    jaggedArray[row][column] += value;
                }
                else
                {
                    jaggedArray[row][column] -= value;
                }
            }

            PrintJaggedArray(jaggedArray);
        }

        private static void PrintJaggedArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsRange(int row, int col, double[][] jaggedArray)
        {
            return row >= 0 && row < jaggedArray.GetLength(0)
                && col >= 0 && col < jaggedArray[row].Length;
        }

        private static void AnalyzingJaggedArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.GetLength(0) - 1; row++)
            {
                if (IsEsqualCurrentNextRow(jaggedArray, row))
                {
                    MultiplyTo2(jaggedArray, row); // current row
                    MultiplyTo2(jaggedArray, row + 1); //next row
                }

                else
                {
                    DivideTo2(jaggedArray, row);
                    DivideTo2(jaggedArray, row + 1);
                }
            }
        }

        private static void DivideTo2(double[][] jaggedArray, int row)
        {
            for (int col = 0; col < jaggedArray[row].Length; col++)
            {
                jaggedArray[row][col] /= 2;
            }
        }

        private static void MultiplyTo2(double[][] jaggedArray, int row)
        {
            for (int col = 0; col < jaggedArray[row].Length; col++)
            {
                jaggedArray[row][col] *= 2;
            }
        }

        private static bool IsEsqualCurrentNextRow(double[][] jaggedArray, int row)
        {
            return jaggedArray[row].Length == jaggedArray[row + 1].Length;
        }
    }
}