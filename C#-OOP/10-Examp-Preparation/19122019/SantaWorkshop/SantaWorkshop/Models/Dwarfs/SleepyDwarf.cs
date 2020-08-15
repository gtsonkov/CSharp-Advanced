namespace SantaWorkshop.Models.Dwarfs
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
            this.Energy -= 5;
            base.Work();
        }
    }
}