using System;
using System.Collections.Generic;

namespace _08_Traffic_Jam
{
    public class TrafficJam
    {
        public static void Main()
        {
            int numberCars = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            string command = Console.ReadLine();
            int passedCars = 0;

            while (command != "end")
            {
                if (command == "green")
                {

                    for (int i = 0; i < numberCars; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        passedCars++;

                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}