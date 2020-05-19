using System;
using System.Collections.Generic;

namespace _07_Hot_Potato
{
    public class HotPotato
    {
        public static void Main()
        {
            string[] names = Console.ReadLine()
                .Split(' ');

            int num = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(names);

            while (queue.Count != 1)
            {
                for (int i = 1; i < num; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                string element = queue.Dequeue();

                Console.WriteLine($"Removed {element}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}