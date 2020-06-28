using System;
using System.Linq;

namespace SantaPresents
{
    class StartUp
    {
        private static string[,] field;
        private static int santaX;
        private static int santaY;

        private static int presentsGivenToNiceKids = 0;
        private static int giftsCount;

        static void Main(string[] args)
        {
            giftsCount = int.Parse(Console.ReadLine());

            int fieldSize = int.Parse(Console.ReadLine());
            field = new string[fieldSize, fieldSize];

            int countNiceKids = 0;

            for (int i = 0; i < fieldSize; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < fieldSize; j++)
                {

                    field[i, j] = input[j];

                    if (field[i, j] == "S")
                    {
                        santaX = i;
                        santaY = j;
                    }
                    if (field[i, j] == "V")
                    {
                        countNiceKids++;
                    }
                }
            }



            while (true)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":

                        field[santaX, santaY] = "-";
                        santaX -= 1;

                        if (field[santaX, santaY] == "V")
                        {
                            presentsGivenToNiceKids++;
                            giftsCount--;
                        }
                        else if (field[santaX, santaY] == "C")
                        {
                            GivePresentsToAll();
                        }

                        field[santaX, santaY] = "S";

                        if (checkEnd(countNiceKids, command))
                        {
                            return;
                        }
                        break;

                    case "down":
                        field[santaX, santaY] = "-";

                        santaX += 1;

                        if (field[santaX, santaY] == "V")
                        {
                            presentsGivenToNiceKids++;
                            giftsCount--;
                        }
                        else if (field[santaX, santaY] == "C")
                        {
                            GivePresentsToAll();
                        }

                        field[santaX, santaY] = "S";

                        if (checkEnd(countNiceKids, command))
                        {
                            return;
                        }
                        break;

                    case "left":
                        field[santaX, santaY] = "-";

                        santaY -= 1;

                        if (field[santaX, santaY] == "V")
                        {
                            presentsGivenToNiceKids++;
                            giftsCount--;
                        }
                        else if (field[santaX, santaY] == "C")
                        {
                            GivePresentsToAll();
                        }

                        field[santaX, santaY] = "S";

                        if (checkEnd(countNiceKids, command))
                        {
                            return;
                        }
                        break;

                    case "right":

                        field[santaX, santaY] = "-";

                        santaY += 1;

                        if (field[santaX, santaY] == "V")
                        {
                            presentsGivenToNiceKids++;
                            giftsCount--;
                        }
                        else if (field[santaX, santaY] == "C")
                        {
                            GivePresentsToAll();
                        }

                        field[santaX, santaY] = "S";

                        if (checkEnd(countNiceKids, command))
                        {
                            return;
                        }
                        break;

                    case "Christmas morning":
                        if (checkEnd(countNiceKids, command))
                        {
                            return;
                        }

                        break;
                }
            }
        }

        private static bool checkEnd(int countNiceKids, string command)
        {
            if (giftsCount == 0 || command == "Christmas morning")
            {
                if (giftsCount == 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                }
                
                PrintField();

                if (countNiceKids == presentsGivenToNiceKids)
                {
                    Console.WriteLine($"Good job, Santa! {countNiceKids} happy nice kid/s.");
                }
                else
                {
                    Console.WriteLine($"No presents for {countNiceKids - presentsGivenToNiceKids} nice kid/s.");
                }

                return true;
            }

            return false;
        }

        private static void PrintField()
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

        private static void GivePresentsToAll()
        {
            //left
            if (field[santaX, santaY - 1] == "V")
            {
                presentsGivenToNiceKids++;
                giftsCount--;
                field[santaX, santaY - 1] = "-";
                if (giftsCount == 0)
                {
                    return;
                }
            }
            else if (field[santaX, santaY - 1] == "X")
            {
                giftsCount--;
                field[santaX, santaY - 1] = "-";
                if (giftsCount == 0)
                {
                    return;
                }
            }

            //right
            if (field[santaX, santaY + 1] == "V")
            {
                presentsGivenToNiceKids++;
                giftsCount--;
                field[santaX, santaY + 1] = "-";
                if (giftsCount == 0)
                {
                    return;
                }
            }
            else if (field[santaX, santaY + 1] == "X")
            {
                giftsCount--;
                field[santaX, santaY + 1] = "-";
                if (giftsCount == 0)
                {
                    return;
                }
            }

            //up
            if (field[santaX - 1, santaY] == "V")
            {
                presentsGivenToNiceKids++;
                giftsCount--;
                field[santaX - 1, santaY] = "-";
                if (giftsCount == 0)
                {
                    return;
                }
            }
            else if (field[santaX - 1, santaY] == "X")
            {
                giftsCount--;
                field[santaX - 1, santaY] = "-";
                if (giftsCount == 0)
                {
                    return;
                }
            }

            //down
            if (field[santaX + 1, santaY] == "V")
            {
                presentsGivenToNiceKids++;
                giftsCount--;
                field[santaX + 1, santaY] = "-";
                if (giftsCount == 0)
                {
                    return;
                }
            }
            else if (field[santaX + 1, santaY] == "X")
            {
                giftsCount--;
                field[santaX + 1, santaY] = "-";
                if (giftsCount == 0)
                {
                    return;
                }
            }
        }
    }
}