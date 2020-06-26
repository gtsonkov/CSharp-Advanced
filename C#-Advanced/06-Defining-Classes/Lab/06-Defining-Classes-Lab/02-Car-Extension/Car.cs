using System;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelConsumption;
        private double fuelQuantity;

        public string Make
        {
            get { return this.make; }
            set { this.make = value;  }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }

        public double FuelConsumtion
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }

        public void Drive(double distance)
        {
            double remainFuel = this.fuelQuantity - distance * this.fuelConsumption;
            if ( remainFuel > 0)
            {
                fuelQuantity -= remainFuel;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public void WhoAmI()
        {
            Console.WriteLine($"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L");
        }
    }
}