using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly List<IPresent> _presents;

        public PresentRepository()
        {
            this._presents = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this._presents;

        public void Add(IPresent model)
        {
            this._presents.Add(model);
        }

        public IPresent FindByName(string name)
        {
            return this._presents.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IPresent model)
        {
            return this._presents.Remove(model);
        }
    }
}