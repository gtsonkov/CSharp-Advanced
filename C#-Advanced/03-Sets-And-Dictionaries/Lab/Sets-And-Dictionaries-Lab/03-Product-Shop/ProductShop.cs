using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Product_Shop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (input != "Revision")
            {
                string[] tokens = input.Split(", ").ToArray();
                if (!shops.ContainsKey(tokens[0]))
                {
                    shops[tokens[0]] = new Dictionary<string, double>();
                }

                shops[tokens[0]].Add(tokens[1], double.Parse(tokens[2]));

                input = Console.ReadLine();
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var p in shop.Value)
                {
                    Console.WriteLine($"Product: {p.Key}, Price: {p.Value}");
                }
            }
        }
    }
}