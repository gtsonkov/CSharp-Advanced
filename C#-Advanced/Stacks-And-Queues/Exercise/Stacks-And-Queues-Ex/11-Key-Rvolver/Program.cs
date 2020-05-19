using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    public class KeyRevolver
    {
        public static void Main()
        {
            int priceOfEachBullet = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);

            int countUseBullets = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                countUseBullets++;

                if (currentBullet > currentLock)
                {
                    Console.WriteLine("Ping!");
                }

                else
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }

                if (countUseBullets % gunBarrel == 0 && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

            else
            {
                int bulletCost = countUseBullets * priceOfEachBullet;
                int earned = valueOfIntelligence - bulletCost;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earned}");
            }
        }
    }
}