namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int hp, double cc)
        {
            this.HorsePower = hp;
            this.cubicCapacity = cc;
        }

        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }

        public double CubicCapacity
        {
            get { return this.cubicCapacity; }

            set { this.cubicCapacity = value; }
        }
    }
}