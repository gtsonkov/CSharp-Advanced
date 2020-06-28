using System;

namespace Problem02
{
    class StartUp
    {
        private static char[,] field;
        private static int X;
        private static int Y;
        private static int food;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            field = new char[n, n];
            food = 0;

            int b1X = -1;
            int b1Y = -1;
            int b2X = -1;
            int b2Y = -1;


            for (int i = 0; i < n; i++)
            {
                char[] inputField = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = inputField[j];

                    if (inputField[j] == 'S')
                    {
                        X = i;
                        Y = j;
                    }
                    if (inputField[j] == 'B')
                    {
                        if (b1X == -1)
                        {
                            b1X = i;
                            b1Y = j;
                        }
                        else
                        {
                            b2X = i;
                            b2Y = j;
                        }
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "up":
                        field[X, Y] = '.';
                        if (X - 1 < 0)
                        {
                            GameOver();
                            PrintField();
                            return;
                        }
                        X -= 1;

                        if (field[X,Y] == '*')
                        {
                            food += 1;
                            field[X, Y] = 'S';
                            if (food == 10)
                            {
                                YouWon();
                                PrintField();
                                return;
                            }
                        }
                        else if(field[X,Y] == 'B')
                        {
                            field[X, Y] = '.';
                            if (X != b1X)
                            {
                                X = b1X;
                                Y = b1Y;

                                field[X, Y] = 'S';
                            }
                            else
                            {
                                X = b2X;
                                Y = b2Y;

                                field[X, Y] = 'S';
                            }
                        }
                        else
                        {
                            field[X, Y] = 'S';
                        }

                        break;
                    case "down":
                        field[X, Y] = '.';
                        if (X + 1 == field.GetLength(0))
                        {
                            GameOver();
                            PrintField();
                            return;
                        }
                        X += 1;


                        if (field[X, Y] == '*')
                        {
                            food += 1;
                            field[X, Y] = 'S';
                            if (food == 10)
                            {
                                YouWon();
                                PrintField();
                                return;
                            }
                        }
                        else if (field[X, Y] == 'B')
                        {
                            field[X, Y] = '.';
                            if (X != b1X)
                            {
                                X = b1X;
                                Y = b1Y;

                                field[X, Y] = 'S';
                            }
                            else
                            {
                                X = b2X;
                                Y = b2Y;

                                field[X, Y] = 'S';
                            }
                        }
                        else
                        {
                            field[X, Y] = 'S';
                        }

                        break;
                    case "left":
                        field[X, Y] = '.';
                        if (Y - 1 < 0)
                        {
                            GameOver();
                            PrintField();
                            return;
                        }
                        Y -= 1;


                        if (field[X, Y] == '*')
                        {
                            food += 1;
                            field[X, Y] = 'S';
                            if (food == 10)
                            {
                                YouWon();
                                PrintField();
                                return;
                            }
                        }

                        else if (field[X, Y] == 'B')
                        {
                            field[X, Y] = '.';
                            if (X != b1X)
                            {
                                X = b1X;
                                Y = b1Y;

                                field[X, Y] = 'S';
                            }
                            else
                            {
                                X = b2X;
                                Y = b2Y;

                                field[X, Y] = 'S';
                            }
                        }
                        else
                        {
                            field[X, Y] = 'S';
                        }

                        break;
                    case "right":
                        field[X, Y] = '.';
                        if (Y + 1 == field.GetLength(1))
                        {
                            GameOver();
                            PrintField();
                            return;
                        }
                        Y += 1;


                        if (field[X, Y] == '*')
                        {
                            food += 1;
                            field[X, Y] = 'S';
                            if (food == 10)
                            {
                                YouWon();
                                PrintField();
                                return;
                            }
                        }
                        else if (field[X, Y] == 'B')
                        {
                            field[X, Y] = '.';
                            if (X != b1X)
                            {
                                X = b1X;
                                Y = b1Y;

                                field[X, Y] = 'S';
                            }
                            else
                            {
                                X = b2X;
                                Y = b2Y;

                                field[X, Y] = 'S';
                            }
                        }
                        else
                        {
                            field[X, Y] = 'S';
                        }

                        break;
                }
            }
        }

        private static void YouWon()
        {
            Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {food}");
        }

        private static void GameOver()
        {
            Console.WriteLine("Game over!");
            Console.WriteLine($"Food eaten: {food}");
        }

        private static void PrintField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}