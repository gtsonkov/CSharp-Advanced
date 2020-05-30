using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _09_Miner
{
    class Miner
    {
        struct Position
        {
            public int row;
            public int col;
            public Position(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        }

        static Position currPosition;
        static string[,] field;
        static int coalCount;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            field = new string[n, n];

            coalCount = 0;

            string[] inputCommands = Console.ReadLine().Split().ToArray();
            Queue<string> commands = new Queue<string>(inputCommands);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();


                for (int j = 0; j < n; j++)
                {
                    field[i, j] = input[j];

                    if (input[j] == "s")
                    {
                        currPosition = new Position(i, j);
                    }

                    else if (input[j] == "c")
                    {
                        coalCount++;
                    }
                }
            }

            while (commands.Count > 0)
            {
                string currComand = commands.Dequeue();
                switch (currComand)
                {
                    case "left":
                        if (checkOnField(0, currPosition.col - 1))
                        {
                            currPosition.col -= 1;

                            var currentGood = getCurrentGood();

                            if (currentGood == "c")
                            {
                                coalCount--;

                                field[currPosition.row, currPosition.col] = "*";
                            }

                            if (checkStatement(currentGood, coalCount))
                            {
                                return;
                            }
                        }

                        break;

                    case "right":
                        if (checkOnField(0, currPosition.col + 1))
                        {
                            currPosition.col += 1;

                            var currentGood = getCurrentGood();

                            if (currentGood == "c")
                            {
                                coalCount--;

                                field[currPosition.row, currPosition.col] = "*";
                            }

                            if (checkStatement(currentGood, coalCount))
                            {
                                return;
                            }
                        }

                        break;

                    case "up":
                        if (checkOnField(currPosition.row - 1, 0))
                        {
                            currPosition.row -= 1;

                            var currentGood = getCurrentGood();

                            if (currentGood == "c")
                            {
                                coalCount--;

                                field[currPosition.row, currPosition.col] = "*";
                            }

                            if (checkStatement(currentGood, coalCount))
                            {
                                return;
                            }
                        }

                        break;

                    case "down":
                        if (checkOnField(currPosition.row + 1, 0))
                        {
                            currPosition.row += 1;

                            var currentGood = getCurrentGood();

                            if (currentGood == "c")
                            {
                                coalCount--;

                                field[currPosition.row, currPosition.col] = "*";
                            }

                            if (checkStatement(currentGood, coalCount))
                            {
                                return;
                            }
                        }

                        break;
                }
            }

            Console.WriteLine($"{coalCount} coals left. ({currPosition.row}, {currPosition.col})");
        }

        private static bool checkStatement(string currentGood, int coalCount)
        {
            if (coalCount == 0)
            {
                Console.WriteLine($"You collected all coals! ({currPosition.row}, {currPosition.col})");
                return true;
            }

            else if (currentGood == "e")
            {
                Console.WriteLine($"Game over! ({currPosition.row}, {currPosition.col})");
                return true;
            }
            return false;
        }

        private static string getCurrentGood()
        {
            return field[currPosition.row, currPosition.col];
        }

        private static bool checkOnField(int row, int col)
        {
            return ((row >= 0) && (row < field.GetLength(0)) && (col >= 0) && (col < field.GetLength(1)));
        }
    }
}