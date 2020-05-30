using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Bombs
    {
        struct Bomb
        {
            public int row;
            public int col;
            public Bomb(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] field = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = input[j];
                }
            }

            int[] BombsPlaces = Console.ReadLine()
                .Replace(",", " ")
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<Bomb> Bombs = new Queue<Bomb>();

            for (int i = 0; i < BombsPlaces.Length - 1; i += 2)
            {
                Bomb currBomb = new Bomb();
                currBomb.row = BombsPlaces[i];
                currBomb.col = BombsPlaces[i + 1];
                Bombs.Enqueue(currBomb);
            }

            while (Bombs.Count > 0)
            {
                Bomb CurrBomb = Bombs.Dequeue();
                if (field[CurrBomb.row, CurrBomb.col] > 0)
                {
                    field = Exploding(field, CurrBomb);
                }
            }

            int aliveCells = 0;
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field[i, j] > 0)
                    {
                        aliveCells += 1;
                        sum += field[i, j];
                    }
                }
            }

            Console.WriteLine("Alive cells: " + aliveCells);
            Console.WriteLine("Sum: " + sum);
            Print(field);
        }

        private static void Print(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] Exploding(int[,] field, Bomb currBomb)
        {
            int power = field[currBomb.row, currBomb.col];

            field[currBomb.row, currBomb.col] = 0;

            bool boardLeft = false;
            bool boardRight = false;
            bool boardUp = false;
            bool boardDown = false;

            if (currBomb.row > 0)
            {
                if (field[currBomb.row - 1, currBomb.col] > 0)
                {
                    field[currBomb.row - 1, currBomb.col] -= power;
                }
            }

            else
            {
                boardLeft = true;
            }

            if ((currBomb.row + 1) < field.GetLength(0))
            {
                if (field[currBomb.row + 1, currBomb.col] > 0)
                {
                    field[currBomb.row + 1, currBomb.col] -= power;
                }
            }

            else
            {
                boardRight = true;
            }

            if (currBomb.col > 0)
            {
                if (field[currBomb.row, currBomb.col - 1] > 0)
                {
                    field[currBomb.row, currBomb.col - 1] -= power;
                }
            }

            else
            {
                boardUp = true;
            }

            if ((currBomb.col + 1) < field.GetLength(1))
            {
                if (field[currBomb.row, currBomb.col + 1] > 0)
                {
                    field[currBomb.row, currBomb.col + 1] -= power;
                }
            }

            else
            {
                boardDown = true;
            }

            if (!boardLeft && !boardRight && !boardUp && !boardDown)
            {
                if (field[currBomb.row + 1, currBomb.col - 1] > 0)
                {
                    field[currBomb.row + 1, currBomb.col - 1] -= power;
                }

                if (field[currBomb.row + 1, currBomb.col + 1] > 0)
                {
                    field[currBomb.row + 1, currBomb.col + 1] -= power;
                }

                if (field[currBomb.row - 1, currBomb.col - 1] > 0)
                {
                    field[currBomb.row - 1, currBomb.col - 1] -= power;
                }

                if (field[currBomb.row - 1, currBomb.col + 1] > 0)
                {
                    field[currBomb.row - 1, currBomb.col + 1] -= power;
                }

                return field;
            }

            if (currBomb.row - 1 >= 0 && currBomb.col - 1 >= 0)
            {
                if (field[currBomb.row - 1, currBomb.col - 1] > 0)
                {
                    field[currBomb.row - 1, currBomb.col - 1] -= power;
                }
            }

            if (currBomb.row + 1 < field.GetLength(0) && currBomb.col - 1 >= 0)
            {
                if (field[currBomb.row + 1, currBomb.col - 1] > 0)
                {
                    field[currBomb.row + 1, currBomb.col - 1] -= power;
                }
            }

            if (currBomb.row + 1 < field.GetLength(0) && currBomb.col + 1 < field.GetLength(1))
            {
                if (field[currBomb.row + 1, currBomb.col + 1] > 0)
                {
                    field[currBomb.row + 1, currBomb.col + 1] -= power;
                }
            }

            if ((currBomb.row - 1 >= 0 && currBomb.col + 1 < field.GetLength(1)))
            {
                if (field[currBomb.row - 1, currBomb.col + 1] > 0)
                {
                    field[currBomb.row - 1, currBomb.col + 1] -= power;
                }
            }

            return field;
        }
    }
}