using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> _dwarfs;

        public DwarfRepository()
        {
            this._dwarfs = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this._dwarfs;

        public void Add(IDwarf model)
        {
            this._dwarfs.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            return this._dwarfs.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDwarf model)
        {
            return this._dwarfs.Remove(model);
        }
    }
}