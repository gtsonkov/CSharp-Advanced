using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Fashion_Boutique
{
    class FashionBotique
    {
        static void Main(string[] args)
        {
            int[] boxInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> box = new Stack<int>(boxInput);

            int currRackState = 0;
            int racksUsed = 1;

            while (box.Count>0)
            {
                int currItem = box.Pop();
                if (currRackState + currItem <= rackCapacity)
                {
                    currRackState += currItem;
                }
                else
                {
                    currRackState = currItem;
                    racksUsed += 1;
                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}