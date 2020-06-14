using System;
using System.Linq;

namespace _04_Add_VAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    double num = double.Parse(x);
                    return num * 1.2;
                })
                .ToList()
                .ForEach(s => Console.WriteLine($"{s:F2}"));
        }
    }
}