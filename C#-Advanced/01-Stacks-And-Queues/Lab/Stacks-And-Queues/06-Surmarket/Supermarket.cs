using System;
using System.Collections.Generic;

namespace _06_Supermarket
{
    class Supermarket
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            Queue<string> names = new Queue<string>();
            while (name != "End")
            {
                if (name == "Paid")
                {
                    while (names.Count > 0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }
                else
                {
                    names.Enqueue(name);
                }

                name = Console.ReadLine();
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}