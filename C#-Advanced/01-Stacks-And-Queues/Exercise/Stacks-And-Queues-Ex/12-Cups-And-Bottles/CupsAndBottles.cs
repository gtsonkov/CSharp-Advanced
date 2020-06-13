using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_Cups_And_Bottles
{
    class CupsAndBottles
    {
        static void Main()
        {
            int[] cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsInput);
            Stack<int> bottles = new Stack<int>(bottlesInput);

            int totalLiters = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Pop();

                if (currentBottle >= currentCup)
                {
                    cups.Dequeue();
                    totalLiters += currentBottle - currentCup;
                }

                else
                {
                    while (true)
                    {
                        if (currentCup - currentBottle <= 0)
                        {
                            cups.Dequeue();
                            totalLiters += currentBottle - currentCup;
                            break;
                        }

                        currentCup -= currentBottle;
                        currentBottle = bottles.Pop();
                    }
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            else if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {totalLiters}");
        }
    }
}
