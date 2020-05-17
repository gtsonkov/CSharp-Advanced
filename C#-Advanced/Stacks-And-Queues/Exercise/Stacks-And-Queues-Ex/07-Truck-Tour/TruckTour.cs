using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Truck_Tour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            
            Queue<Dictionary<int, int>> pumps = new Queue<Dictionary<int, int>>(numberOfPumps);
            int index = 0;

            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                Dictionary<int, int> crrPump = new Dictionary<int, int>(1);
                crrPump.Add(input[0], input[1]);

                pumps.Enqueue(crrPump);

            }

            while (true)
            {
                int fuelInTank = 0;

                foreach (var pump in pumps)
                {
                    int fuelAmount = pump.Keys.ToArray()[0];
                    int distance = pump.Values.ToArray()[0];

                    fuelInTank += (fuelAmount - distance);

                    if (fuelInTank < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        index++;
                        break;
                    }
                }

                if (fuelInTank > 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}