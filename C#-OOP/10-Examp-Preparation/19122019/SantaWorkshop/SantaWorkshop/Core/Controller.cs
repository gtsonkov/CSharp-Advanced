using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository _dwarfs;

        private PresentRepository _presets;

        public Controller()
        {
            this._dwarfs = new DwarfRepository();
            this._presets = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf currDwarf = null;
            switch (dwarfType)
            {
                case "HappyDwarf":
                    currDwarf = new HappyDwarf(dwarfName);
                    break;

                case "SleepyDwarf":
                    currDwarf = new SleepyDwarf(dwarfName);
                    break;

                default:
                    throw new InvalidOperationException("Invalid dwarf type.");
            }

            this._dwarfs.Add(currDwarf);

            string msg = string.Format(OutputMessages.DwarfAdded,currDwarf.GetType().Name,currDwarf.Name);

            return msg;
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var currDwarf = _dwarfs.FindByName(dwarfName);

            if (currDwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            Instrument currInstrument = new Instrument(power);

            currDwarf.AddInstrument(currInstrument);

            string msg = string.Format(OutputMessages.InstrumentAdded, currInstrument.Power, currDwarf.Name);

            return msg;
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            Present currPresent = new Present(presentName, energyRequired);

            this._presets.Add(currPresent);

            string msg = string.Format(OutputMessages.PresentAdded, presentName);

            return msg;
        }

        public string CraftPresent(string presentName)
        {
            var team = this._dwarfs.Models
                .Where(d => d.Energy >= 50)
                .OrderByDescending(d => d.Energy);

            if (!team.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            Workshop workshop = new Workshop();

            var presentToCraft = this._presets.FindByName(presentName);

            foreach (var d in team)
            {

                workshop.Craft(presentToCraft, d);

                if (d.Energy == 0)
                {
                    this._dwarfs.Remove(d);
                }

                if (presentToCraft.IsDone())
                {
                    string msg = string.Format(OutputMessages.PresentIsDone, presentName);

                    return msg;
                }
            }

            string msgNotDone = string.Format(OutputMessages.PresentIsNotDone,presentName);

            return msgNotDone;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this._presets.Models.Where(p => p.IsDone()).Count()} presents are done!");
            sb.AppendLine("Dwarfs info:");
            var dwarfs = this._dwarfs.Models;

            foreach (var dw in dwarfs)
            {
                sb.AppendLine(dw.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}