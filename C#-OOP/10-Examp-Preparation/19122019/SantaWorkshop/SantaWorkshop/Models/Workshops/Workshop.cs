using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System.Linq;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (true)
            {
                if (dwarf.Energy != 0 && dwarf.Instruments.Any(i => !i.IsBroken() && !present.IsDone()))
                {
                    if (dwarf.Instruments.Any(i => !i.IsBroken()))
                    {
                        var instrument = dwarf.Instruments.FirstOrDefault(x => !x.IsBroken());
                        instrument.Use();
                        dwarf.Work();
                        present.GetCrafted();
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}