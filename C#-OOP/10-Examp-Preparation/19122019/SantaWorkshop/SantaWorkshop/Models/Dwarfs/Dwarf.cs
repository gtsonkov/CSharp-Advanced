using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string _name;
        private int _energy;
        private ICollection<IInstrument> _instruments;

        public Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this._instruments = new List<IInstrument>();
        }

        public string Name
        { get
            {
                return this._name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Dwarf name cannot be null or empty.");
                }

                this._name = value;
            }
        }

        public int Energy
        {
            get
            {
                return this._energy;
            }

            //private
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this._energy = value;
            }
        }

        public ICollection<IInstrument> Instruments => this._instruments;

        public void AddInstrument(IInstrument instrument)
        {
            this._instruments.Add(instrument);
        }

        public virtual void Work()
        {
            this.Energy -= 10;
        }
    }
}