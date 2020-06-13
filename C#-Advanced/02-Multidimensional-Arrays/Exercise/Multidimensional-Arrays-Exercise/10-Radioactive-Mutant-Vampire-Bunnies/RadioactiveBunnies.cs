using System;

namespace RadioactiveBunnies
{
    using System.Collections.Generic;
    using System.Linq;
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

    struct BunnySpreadResult
    {
        public bool alive;
        public char[,] matrix;

        public BunnySpreadResult(bool alive, char[,] matrix)
        {
            this.alive = alive;
            this.matrix = matrix;
        }
    }

    class RadioactiveBunnies
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[size[0], size[1]];
            Position PlayerPosition = new Position();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];

                    if (input[j] == 'P')
                    {
                        PlayerPosition.row = i;
                        PlayerPosition.col = j;
                    }
                }
            }
            char[] command = Console.ReadLine()
                .ToCharArray();

            char Bunny = 'B';
            char Player = 'P';

            for (int i = 0; i < command.Length; i++)
            {
                //Move Player (Save last Position and check if alive or escaped)
                switch (command[i])
                {
                    case 'U':

                        if (PlayerPosition.row - 1 >= 0)
                        {
                            matrix[PlayerPosition.row, PlayerPosition.col] = '.';
                            PlayerPosition.row -= 1;

                            if (matrix[PlayerPosition.row, PlayerPosition.col] == Bunny)
                            {
                                BunnySpreadResult ResultDeadMove = BunnyesSpread(matrix);
                                matrix = ResultDeadMove.matrix;
                                GameOver(matrix, PlayerPosition);
                                return;
                            }

                            matrix[PlayerPosition.row + 1, PlayerPosition.col] = '.';
                            matrix[PlayerPosition.row, PlayerPosition.col] = Player;
                        }

                        else
                        {
                            matrix[PlayerPosition.row, PlayerPosition.col] = '.';
                            BunnySpreadResult ResultDeadMove = BunnyesSpread(matrix);
                            matrix = ResultDeadMove.matrix;
                            Escaped(matrix, PlayerPosition);
                            return;
                        }

                        break;

                    case 'D':
                        if (PlayerPosition.row + 1 < matrix.GetLength(0))
                        {
                            matrix[PlayerPosition.row, PlayerPosition.col] = '.';
                            PlayerPosition.row += 1;

                            if (matrix[PlayerPosition.row, PlayerPosition.col] == Bunny)
                            {
                                BunnySpreadResult ResultDeadMove = BunnyesSpread(matrix);
                                matrix = ResultDeadMove.matrix;
                                GameOver(matrix, PlayerPosition);
                                return;
                            }

                            matrix[PlayerPosition.row, PlayerPosition.col] = Player;
                        }

                        else
                        {
                            matrix[PlayerPosition.row, PlayerPosition.col] = '.';
                            BunnySpreadResult ResultDeadMove = BunnyesSpread(matrix);
                            matrix = ResultDeadMove.matrix;
                            Escaped(matrix, PlayerPosition);
                            return;
                        }

                        break;

                    case 'L':

                        if (PlayerPosition.col - 1 >= 0)
                        {
                            matrix[PlayerPosition.row, PlayerPosition.col] = '.';
                            PlayerPosition.col -= 1;
                            if (matrix[PlayerPosition.row, PlayerPosition.col] == Bunny)
                            {
                                BunnySpreadResult ResultDeadMove = BunnyesSpread(matrix);
                                matrix = ResultDeadMove.matrix;
                                GameOver(matrix, PlayerPosition);
                                return;
                            }
                            matrix[PlayerPosition.row, PlayerPosition.col] = Player;
                        }

                        else
                        {
                            matrix[PlayerPosition.row, PlayerPosition.col] = '.';
                            BunnySpreadResult ResultDeadMove = BunnyesSpread(matrix);
                            matrix = ResultDeadMove.matrix;
                            Escaped(matrix, PlayerPosition);
                            return;
                        }

                        break;

                    case 'R':

                        if (PlayerPosition.col + 1 < matrix.GetLength(1))
                        {
                            matrix[PlayerPosition.row, PlayerPosition.col] = '.';
                            PlayerPosition.col += 1;
                            if (matrix[PlayerPosition.row, PlayerPosition.col] == Bunny)
                            {
                                BunnySpreadResult ResultDeadMove = BunnyesSpread(matrix);
                                matrix = ResultDeadMove.matrix;
                                GameOver(matrix, PlayerPosition);
                                return;
                            }
                            matrix[PlayerPosition.row, PlayerPosition.col] = Player;
                        }

                        else
                        {
                            matrix[PlayerPosition.row, PlayerPosition.col] = '.';
                            BunnySpreadResult ResultDeadMove = BunnyesSpread(matrix);
                            matrix = ResultDeadMove.matrix;
                            Escaped(matrix, PlayerPosition);
                            return;
                        }

                        break;
                }

                //Bunnyes Spread
                BunnySpreadResult Result = BunnyesSpread(matrix);
                matrix = Result.matrix;

                if (!Result.alive)
                {
                    GameOver(matrix, PlayerPosition);
                    return;
                }
            }
        }

        private static void Escaped(char[,] matrix, Position playerPosition)
        {
            //matrix[playerPosition.row, playerPosition.col] = '.';
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            Console.Write("won: {0} {1}", playerPosition.row, playerPosition.col);
            Console.WriteLine();
        }

        private static void GameOver(char[,] matrix, Position playerPosition)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.Write("dead: {0} {1}", playerPosition.row, playerPosition.col);
            Console.WriteLine();
        }

        public static BunnySpreadResult BunnyesSpread(char[,] matrix)
        {
            char Bomb = 'B';
            char Player = 'P';
            bool alive = true;

            List<Position> BunniesCurrPos = new List<Position>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        BunniesCurrPos.Add(new Position(i, j));
                    }
                }
            }

            for (int i = 0; i < BunniesCurrPos.Count; i++)
            {
                if (BunniesCurrPos[i].row + 1 < matrix.GetLength(0))
                {
                    if (matrix[BunniesCurrPos[i].row + 1, BunniesCurrPos[i].col] == Player)
                    {
                        alive = false;
                    }

                    matrix[BunniesCurrPos[i].row + 1, BunniesCurrPos[i].col] = Bomb;
                }

                if ((BunniesCurrPos[i].col + 1 < matrix.GetLength(1)))
                {
                    if (matrix[BunniesCurrPos[i].row, BunniesCurrPos[i].col + 1] == Player)
                    {
                        alive = false;
                    }

                    matrix[BunniesCurrPos[i].row, BunniesCurrPos[i].col + 1] = Bomb;
                }

                if (BunniesCurrPos[i].row - 1 >= 0)
                {
                    if (matrix[BunniesCurrPos[i].row - 1, BunniesCurrPos[i].col] == Player)
                    {
                        alive = false;
                    }

                    matrix[BunniesCurrPos[i].row - 1, BunniesCurrPos[i].col] = Bomb;
                }

                if ((BunniesCurrPos[i].col - 1 >= 0))
                {
                    if (matrix[BunniesCurrPos[i].row, BunniesCurrPos[i].col - 1] == Player)
                    {
                        alive = false;
                    }

                    matrix[BunniesCurrPos[i].row, BunniesCurrPos[i].col - 1] = Bomb;
                }
            }

            BunnySpreadResult Result = new BunnySpreadResult(alive, matrix);
            return Result;
        }
    }
}