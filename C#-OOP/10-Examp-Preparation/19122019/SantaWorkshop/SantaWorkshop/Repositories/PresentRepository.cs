using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        public IReadOnlyCollection<IPresent> Models => throw new System.NotImplementedException();

        public void Add(IPresent model) => throw new System.NotImplementedException();
        public IPresent FindByName(string name) => throw new System.NotImplementedException();
        public bool Remove(IPresent model) => throw new System.NotImplementedException();
    }
}