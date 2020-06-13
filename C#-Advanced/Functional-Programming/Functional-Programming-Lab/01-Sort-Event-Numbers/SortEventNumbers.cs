using System;
using System.Linq;

namespace _01_Sort_Event_Numbers
{
    class SortEventNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => (x % 2) == 0)
                .OrderBy(x => x)
                .ToArray()));
        }
    }
}