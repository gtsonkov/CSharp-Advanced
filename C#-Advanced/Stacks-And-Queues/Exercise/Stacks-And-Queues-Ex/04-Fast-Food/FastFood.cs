using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_Fast_Food
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            var ordersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(ordersInput);

            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                if (orders.Peek() <= foodQuantity)
                {
                    int order = orders.Dequeue();
                    foodQuantity -= order;
                }
                else
                {
                    Console.WriteLine("Orders left: " + String.Join(" ",orders));
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}