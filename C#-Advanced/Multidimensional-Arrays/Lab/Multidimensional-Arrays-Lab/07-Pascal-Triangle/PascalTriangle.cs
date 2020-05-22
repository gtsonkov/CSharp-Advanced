using System;

namespace _07_Pascal_Triangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int currRow = 1;

            long[][] triangle = new long[rows][];

            for (int i = 0; i < rows; i++)
            {
                triangle[i] = new long[currRow];
                triangle[i][0] = 1;
                triangle[i][currRow - 1] = 1;

                if (currRow > 2)
                {
                    for (int j = 1; j < currRow-1; j++)
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }

                currRow++;
            }

            foreach (var arr in triangle)
            {
                Console.WriteLine(string.Join(" ",arr));
            }
        }
    }
}