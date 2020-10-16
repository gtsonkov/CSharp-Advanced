using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private int _power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get
            {
                return this._power;
            }

            private set
            {
                this._power = value > 0 ? value : 0;
            }
        }

        public bool IsBroken() => this.Power == 0;

        public void Use()
        {
            this.Power -= 10;
        }
    }
}