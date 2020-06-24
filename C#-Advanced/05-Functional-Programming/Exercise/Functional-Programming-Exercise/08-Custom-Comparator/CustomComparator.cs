using System;
using System.Linq;

namespace _08_Custom_Comparator
{
    class CustomComparator
    {


        static void Main(string[] args)
        {
            Func<int, int, int> ComapreOddAdd = delegate (int x, int y)
            {
                int result = 0;

                if (x % 2 == 0 && y % 2 != 0) 
                {
                    result = -1;
                }
                else if (x % 2 != 0 && y % 2 == 0 )
                {
                    result = 1;
                }
                else
                {
                    result = x.CompareTo(y);
                }

                return result;
            };
                int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(nums, (x, y) => ComapreOddAdd(x, y));

            Console.WriteLine(string.Join(" ", nums));

        }
    }
}