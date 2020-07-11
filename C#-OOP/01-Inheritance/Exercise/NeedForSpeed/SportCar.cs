namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DEFAUFL_FUEL_CONSUMPTION = 10.00;
        public SportCar(int hp, double fuel)
            : base(hp, fuel)
        {
        }

        public override double FuelConsumption => DEFAUFL_FUEL_CONSUMPTION;

        public override void Drive(double kilometer)
        {
            this.Fuel -= (kilometer * this.FuelConsumption);
        }
    }
}