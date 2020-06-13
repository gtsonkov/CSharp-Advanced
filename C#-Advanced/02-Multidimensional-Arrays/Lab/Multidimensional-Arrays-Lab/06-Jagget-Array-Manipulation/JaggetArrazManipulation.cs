using System;
using System.Linq;

namespace _06_Jagget_Array_Manipulation
{
    class JaggetArrayManipulation
    {
        static void Main(string[] args)
        {
            int rowNumber = int.Parse(Console.ReadLine()); // Read row numbers

            int[][] jaggetArr = new int[rowNumber][]; // Create Jagged Array

            for (int i = 0; i < rowNumber; i++) //Fill Jaget array with user input
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggetArr[i] = arr;
            }

            //Read and execute commands

            string[] tokens = Console.ReadLine().Split().ToArray();

            while (tokens[0] != "END")
            {
                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (AreValideCoordinates(row,col,jaggetArr))
                {
                    switch (command)
                    {
                        case "Add":

                            jaggetArr[row][col] += value;

                            break;

                        case "Subtract":

                            jaggetArr[row][col] -= value;

                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
               

                tokens = Console.ReadLine().Split().ToArray();
            }

            //Print Result
            foreach (var arr in jaggetArr)
            {
                Console.WriteLine(string.Join(" ",arr));
            }
        }

        private static bool AreValideCoordinates(int row, int col, int[][] jaggetArr)
        {
            return ((row >=0 ) 
                && (row <= (jaggetArr.Length - 1)) 
                && (col >= 0) 
                && (col <= (jaggetArr[row].Length - 1)));
        }
    }
}