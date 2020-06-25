using System;
using System.Linq;

namespace _03_Custom_Min_Function
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Func<int[], int> GetMinNumber = x =>
            {
                int minNumber = x[0];
                foreach (var n in x)
                {
                    if (n < minNumber)
                    {
                        minNumber = n;
                    }
                }
                return minNumber;
            };

            Console.WriteLine(GetMinNumber(numbers));
        }
    }
}