using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<List<Tire>> allTires = new List<List<Tire>>();
            List<Engine> allEngines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                List<Tire> currTires = new List<Tire>();

                string[] inputFilter = input.Split().ToArray();

                for (int i = 0; i < inputFilter.Length; i+=2)
                {
                    int year = int.Parse(inputFilter[i]);
                    double pressure = double.Parse(inputFilter[i + 1]);

                    currTires.Add(new Tire(year,pressure));
                }

                allTires.Add(currTires);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Engines done")
            {
                string[] inputFilter = input.Split().ToArray();
                int hp = int.Parse(inputFilter[0]);
                double cc = double.Parse(inputFilter[1]);

                allEngines.Add(new Engine(hp, cc));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Show special")
            {
                string[] inputFilter = input.Split().ToArray();

                string make = inputFilter[0];
                string model = inputFilter[1];
                int year = int.Parse(inputFilter[2]);
                double fuelQuatity = double.Parse(inputFilter[3]);
                double fuelConsumption = double.Parse(inputFilter[4]);
                Tire[] tires = allTires[int.Parse(inputFilter[5])].ToArray();
                Engine eng = allEngines[int.Parse(inputFilter[6])];

                cars.Add(new Car(make, model, year, fuelQuatity, fuelConsumption, eng, tires));

                input = Console.ReadLine();
            }

            var finalCarList = cars.Where(
                c => c.Year >= 2017 &&
                c.Engine.HorsePower > 330 &&
                c.Tires.Sum(x => x.Pressure) <= 10
                );

            foreach (var car in finalCarList)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}