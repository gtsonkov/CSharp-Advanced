namespace Restaurant
{
    public class Beverage : Product
    {
        public double Milliliters { get; private set; }
        public Beverage(string name, decimal price, double milliliters) 
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }
    }
}