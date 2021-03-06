﻿namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int InitialEnergy = 50;

        public SleepyDwarf(string name)
            : base(name, InitialEnergy)
        {

        }

        public override void Work()
        {
            base.Work();
            this.Energy -= 5;
        }
    }
}