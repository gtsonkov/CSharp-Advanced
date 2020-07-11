using System.Threading;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAUFL_FUEL_CONSUMPTION = 1.25;

        public Vehicle(int hp, double fuel)
        {
            this.HorsePower = hp;
            this.Fuel = fuel;
        }

        public virtual double FuelConsumption => DEFAUFL_FUEL_CONSUMPTION;

        public double Fuel { get; protected set; }

        public int HorsePower { get; private set; }

        public virtual void Drive(double kilometer)
        {
            this.Fuel -= (kilometer * this.FuelConsumption);
        }
    }
}