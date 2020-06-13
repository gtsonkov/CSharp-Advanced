using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            while (n > 0)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();
                string color = input[0];
                string[] clothes = input[1].Split(",").ToArray();

                if (wardrobe.ContainsKey(color))
                {
                    foreach (var item in clothes)
                    {
                        if (wardrobe[color].ContainsKey(item))
                        {
                            wardrobe[color][item]++;
                        }

                        else
                        {
                            wardrobe[color].Add(item, 1);
                        }
                    }
                }

                else
                {
                    Dictionary<string, int> currClothes = new Dictionary<string, int>();
                    foreach (var item in clothes)
                    {
                        if (currClothes.ContainsKey(item))
                        {
                            currClothes[item]++;
                        }

                        else
                        {
                            currClothes.Add(item, 1);
                        }
                    }

                    wardrobe.Add(color, currClothes);
                }
                
                n--;
            }

            string[] tokens = Console.ReadLine().Split(" ").ToArray();

            foreach (var col in wardrobe)
            {
                Console.WriteLine($"{col.Key} clothes:");
                foreach (var c in col.Value)
                {
                    if (col.Key == tokens[0] && c.Key == tokens[1])
                    {
                        Console.WriteLine($"* {c.Key} - {c.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {c.Key} - {c.Value}");
                    }
                }
            }
        }
    }
}