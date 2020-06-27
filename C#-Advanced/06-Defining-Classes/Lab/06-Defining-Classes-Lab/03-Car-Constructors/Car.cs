using System;
using System.Text;
using System.Threading;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelConsumption;
        private double fuelQuantity;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200.00;
            this.FuelConsumption = 10.00;
        }

        public Car(string make, string model, int year)
            :this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuatity, double fuelConsumption)
            :this(make,model,year)
        {
            this.FuelQuantity = fuelQuatity;
            this.FuelConsumption = fuelConsumption;
        }

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
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

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set
            {
                this.fuelConsumption = value;
            }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                this.fuelQuantity = value;
            }
        }

        public void Drive(double distance)
        {
            bool canContinue = this.FuelQuantity - ((distance/100) * this.FuelConsumption) > 0;
            if (canContinue)
                this.FuelQuantity -= (distance/100) * this.FuelConsumption;
            else
                Console.WriteLine("Not enough fuel to perform this trip!");
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");
            return sb.ToString();
        }
    }
}