using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampPrep
{
    public class StratUp
    {
        static void Main(string[] args)
        {
            int[] numsFor1Loot = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numsFor2Loot = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> loot1 = new Queue<int>(numsFor1Loot);
            Stack<int> loot2 = new Stack<int>(numsFor2Loot);

            int climedItems = 0;

            while (loot1.Count > 0 && loot2.Count > 0)
            {
                int sum = loot1.Peek() + loot2.Peek();

                if (sum % 2 == 0)
                {
                    climedItems += sum;
                    loot1.Dequeue();
                    loot2.Pop();
                }
                else
                {
                    loot1.Enqueue(loot2.Pop());
                }
            }

            if (loot1.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
                if (climedItems >= 100 )
                {
                    Console.WriteLine($"Your loot was epic! Value: {climedItems}");
                }
                else
                {
                    Console.WriteLine($"Your loot was poor... Value: {climedItems}");
                }
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
                if (climedItems >= 100)
                {
                    Console.WriteLine($"Your loot was epic! Value: {climedItems}");
                }
                else
                {
                    Console.WriteLine($"Your loot was poor... Value: {climedItems}");
                }
            }
        }
    }
}