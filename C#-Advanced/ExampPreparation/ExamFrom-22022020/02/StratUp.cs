using System;

namespace ExampPrepFebCFSA
{
    class StratUpAA
    {
        private static char[,] field;

        private static int playerX;
        private static int playerY;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            field = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size; j++)
                {
                    field[i, j] = input[j];
                    if (input[j] == 'f')
                    {
                        playerX = i;
                        playerY = j;
                    }
                }
            }

            while (countOfCommands != 0)
            {
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "up":
                        field[playerX, playerY] = '-';

                        MoveUp();

                        if (field[playerX, playerY] == 'B')
                        {
                            MoveUp();
                        }
                        else if (field[playerX, playerY] == 'T')
                        {
                            MoveDown();
                        }
                        
                        if (field[playerX, playerY] == 'F')
                        {
                            field[playerX, playerY] = 'f';
                            Console.WriteLine("Player won!");
                            PrintField();
                            return;
                        }

                        field[playerX, playerY] = 'f';

                        break;

                    case "down":
                        field[playerX, playerY] = '-';

                        MoveDown();

                        if (field[playerX, playerY] == 'B')
                        {
                            MoveDown();
                        }
                        else if (field[playerX, playerY] == 'T')
                        {
                            MoveUp();
                        }
                        
                        if (field[playerX, playerY] == 'F')
                        {
                            field[playerX, playerY] = 'f';
                            Console.WriteLine("Player won!");
                            PrintField();
                            return;
                        }

                        field[playerX, playerY] = 'f';
                        break;

                    case "left":
                        field[playerX, playerY] = '-';

                        MoveLeft();

                        if (field[playerX, playerY] == 'B')
                        {
                            MoveLeft();
                        }
                        else if (field[playerX, playerY] == 'T')
                        {
                            MoveRight();
                        }

                        if (field[playerX, playerY] == 'F')
                        {
                            field[playerX, playerY] = 'f';
                            Console.WriteLine("Player won!");
                            PrintField();
                            return;
                        }

                        field[playerX, playerY] = 'f';
                        break;

                    case "right":
                        field[playerX, playerY] = '-';

                        MoveRight();

                        if (field[playerX, playerY] == 'B')
                        {
                            MoveRight();
                        }
                        else if (field[playerX, playerY] == 'T')
                        {
                            MoveLeft();
                        }
                        
                        if (field[playerX, playerY] == 'F')
                        {
                            field[playerX, playerY] = 'f';
                            Console.WriteLine("Player won!");
                            PrintField();
                            return;
                        }

                        field[playerX, playerY] = 'f';
                        break;
                }

                countOfCommands--;
            }

            Console.WriteLine("Player lost!");
            PrintField();
        }

        private static void MoveRight()
        {
            if (playerY + 1 > field.GetLength(1) - 1)
            {
                playerY = 0;
            }
            else
            {
                playerY += 1;
            }
        }
        private static void MoveLeft()
        {
            if (playerY - 1 < 0)
            {
                playerY = field.GetLength(1) - 1;
            }
            else
            {
                playerY -= 1;
            }
        }

        private static void MoveDown()
        {
            if (playerX + 1 > field.GetLength(0) - 1)
            {
                playerX = 0;
            }
            else
            {
                playerX += 1;
            }
        }

        private static void MoveUp()
        {
            if (playerX - 1 < 0)
            {
                playerX = field.GetLength(0) - 1;
            }
            else
            {
                playerX -= 1;
            }
        }

        private static void PrintField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}