namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DEFAUFL_FUEL_CONSUMPTION = 3.0;

        public Car(int hp, double fuel) 
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