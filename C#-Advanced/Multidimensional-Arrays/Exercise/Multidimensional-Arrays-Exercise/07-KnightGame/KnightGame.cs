using System;

namespace _07_KnightGame
{
    class KnightGame
    {
        struct Position
        {
            public byte row;
            public byte col;
            public Position(byte row, byte col)
            {
                this.row = row;
                this.col = col;
            }
        }
        static void Main(string[] args)
        {
            byte size = byte.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (byte i = 0; i < size; i++)
            {
                string fillField = Console.ReadLine();
                for (byte j = 0; j < size; j++)
                {
                    matrix[i, j] = fillField[j];
                }
            }

            int removed = 0;
            var CurrPos = new Position();
            var MaxPos = new Position();

            while (true)
            {
                byte maxAttack = 0;
                byte attacks = 0;

                for (byte i = 0; i < size; i++)
                {
                    CurrPos.row = i;
                    for (byte j = 0; j < size; j++)
                    {
                        CurrPos.col = j;
                        if (matrix[CurrPos.row, CurrPos.col] == 'K')
                        {
                            for (byte k = 0; k < 8; k++)
                            {
                                if (CheckConditions(matrix, CurrPos, size, k))
                                {
                                    attacks += 1;
                                }
                            }

                            if (attacks > maxAttack)
                            {
                                maxAttack = attacks;
                                MaxPos = CurrPos;
                            }
                            attacks = 0;
                        }
                    }
                }

                if (maxAttack > 0)
                {
                    matrix[MaxPos.row, MaxPos.col] = '0';
                    removed++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removed);
            //Print Option
            //for (byte i = 0; i < size; i++)
            //{
            //    for (int j = 0; j < size; j++)
            //    {
            //        Console.Write(matrix[i,j]);
            //    }
            //    Console.WriteLine();
            //}
        }
        private static bool CheckConditions(char[,] matrix, Position tempPos, byte size, byte index)
        {
            switch (index)
            {
                case 0:
                    tempPos.row -= 1;
                    tempPos.col -= 2;
                    break;
                case 1:
                    tempPos.row += 1;
                    tempPos.col -= 2;
                    break;
                case 2:
                    tempPos.row -= 1;
                    tempPos.col += 2;
                    break;
                case 3:
                    tempPos.row += 1;
                    tempPos.col += 2;
                    break;
                case 4:
                    tempPos.row -= 2;
                    tempPos.col -= 1;
                    break;
                case 5:
                    tempPos.row -= 2;
                    tempPos.col += 1;
                    break;
                case 6:
                    tempPos.row += 2;
                    tempPos.col -= 1;
                    break;
                case 7:
                    tempPos.row += 2;
                    tempPos.col += 1;
                    break;
            }
            //Check InBoarder
            if (tempPos.row >= 0
            && tempPos.col >= 0
            && tempPos.row < size
            && tempPos.col < size)
            {
                //Chek if Attack
                if (matrix[tempPos.row, tempPos.col] == 'K')
                {
                    return true;
                }
            }
            return false;
        }
    }
}