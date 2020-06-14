using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Filter_By_Age
{
    class FilterByAge
    {
        public static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;
                
                case "older":
                    return x => x >= age;

                default: return null; 
            }
        }

        public static Action<KeyValuePair<string,int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name": return p => Console.WriteLine($"{p.Key}");

                case "name age": return p => Console.WriteLine($"{p.Key} - {p.Value}");

                default: return null;
            }
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var data = new Dictionary<string, int>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ")
                    .ToArray();
                data.Add(input[0], int.Parse(input[1]));
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string outputFormat = Console.ReadLine();
            var getDataByCondition = CreateTester(condition,age);

            var printer = CreatePrinter(outputFormat);

            var filteredData = data.Where(x => getDataByCondition(x.Value));

            foreach (var p in filteredData)
            {
                printer(p);
            }

        }
    }
}