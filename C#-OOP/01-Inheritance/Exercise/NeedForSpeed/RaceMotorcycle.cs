namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DEFAUFL_FUEL_CONSUMPTION = 8;

        public RaceMotorcycle(int hp, double fuel) 
            : base(hp, fuel)
        {
        }

        public override double FuelConsumption => DEFAUFL_FUEL_CONSUMPTION;

        public override void Drive(double kilometer)
        {
            base.Fuel -= (kilometer * this.FuelConsumption);
        }
    }
}
