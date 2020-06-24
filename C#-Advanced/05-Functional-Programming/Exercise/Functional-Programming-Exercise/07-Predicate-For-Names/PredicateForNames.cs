using System;
using System.Linq;

namespace _07_Predicate_For_Names
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int maxLenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split(" ").Where(x => x.Length <= maxLenght).ToList();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}