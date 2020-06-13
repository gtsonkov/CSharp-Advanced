using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Basic_Queue_Operation
{
    class BasicQueueOperation
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>(tokens[0]);

            for (int i = 0; i < tokens[0]; i++)
            {
                int elementToPush = elements[i];

                queue.Enqueue(elementToPush);
            }

            for (int i = 0; i < tokens[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(tokens[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallestElement = 0;

                if (queue.Count > 0)
                {
                    smallestElement = queue.Dequeue();

                    while (queue.Count > 0)
                    {
                        int currElement = queue.Dequeue();
                        if (currElement < smallestElement)
                        {
                            smallestElement = currElement;
                        }
                    }
                }

                Console.WriteLine(smallestElement);
            }
        }
    }
}