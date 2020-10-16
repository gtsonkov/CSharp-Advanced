using SantaWorkshop.Models.Presents.Contracts;
using System;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        private string _name;
        private int _energyRequired;

        public Present(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get
            {
                return this._name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Present name cannot be null or empty.");
                }

                this._name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return this._energyRequired;
            }

            private set
            {
                this._energyRequired = value > 0 ? value : 0;
            }
        }

        public void GetCrafted()
        {
            this.EnergyRequired -= 10;
        }

        public bool IsDone()
        {
            return this.EnergyRequired == 0;
        }
    }
}