using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Parking_Lot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string[] input = Console.ReadLine().Split(", ").ToArray();

            while (input[0] != "END")
            {
                if (input[0] == "IN")
                {
                    parking.Add(input[1]);
                }

                else
                {
                    parking.Remove(input[1]);
                }

                input = Console.ReadLine().Split(", ").ToArray();
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }
        }
    }
}