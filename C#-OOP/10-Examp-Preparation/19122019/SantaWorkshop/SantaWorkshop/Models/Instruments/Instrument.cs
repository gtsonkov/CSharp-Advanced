using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private int _energy;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get
            {
                return this._energy;
            }

            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this._energy = value;
            }
        }

        public bool IsBroken() => this.Power > 0;

        public void Use()
        {
            this.Power -= 10;
        }
    }
}