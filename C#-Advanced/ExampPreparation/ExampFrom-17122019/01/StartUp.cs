using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaGifts
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> toys = new Dictionary<string, int>();
            toys.Add("Doll", 150);
            toys.Add("Wooden train", 250);
            toys.Add("Teddy bear", 300);
            toys.Add("Bicycle", 400);

            Dictionary<string, int> craftedToys = new Dictionary<string, int>();


            int[] inputMaterials = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] inputMagickLevel = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> materials = new Stack<int>(inputMaterials);
            Queue<int> magickLevels = new Queue<int>(inputMagickLevel);

            while (materials.Count > 0 && magickLevels.Count > 0)
            {
                int material = materials.Peek();
                int magickLevel = magickLevels.Peek();
                int totalLevel = material * magickLevel;
                if (toys.Values.Contains(totalLevel))
                {
                    var name = toys.FirstOrDefault(x => x.Value == totalLevel).Key;

                    if (craftedToys.ContainsKey(name))
                    {
                        craftedToys[name] += 1;
                    }
                    else
                    {
                        craftedToys.Add(name, 1);
                    }

                    materials.Pop();
                    magickLevels.Dequeue();
                }
                else if (totalLevel < 0)
                {
                    material = materials.Pop();
                    magickLevel = magickLevels.Dequeue();

                    materials.Push(material + magickLevel);
                }
                else if (totalLevel == 0)
                {
                    if (material == 0)
                    {
                        materials.Pop();
                    }

                    if (magickLevel == 0)
                    {
                        magickLevels.Dequeue();
                    }
                }
                else
                {
                    magickLevels.Dequeue();
                    materials.Pop();
                    material += 15;
                    materials.Push(material);
                }
            }


            if ((craftedToys.ContainsKey("Doll") && craftedToys.ContainsKey("Wooden train")) || (craftedToys.ContainsKey("Teddy bear") && craftedToys.ContainsKey("Bicycle")))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Count > 0)
            {
                Console.WriteLine("Materials left: " + string.Join(", ", materials));
            }

            if (magickLevels.Count > 0)
            {
                Console.WriteLine("Magic left: " + string.Join(", ", magickLevels));
            }

            foreach (var item in craftedToys.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}