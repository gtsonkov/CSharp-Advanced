using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> _guns;

        public GunRepository()
        {
            this._guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
        {
            get
            {
                return this._guns;
            }
        }

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this._guns.Add(model);
        }

        public IGun FindByName(string name)
        {
            return this._guns.FirstOrDefault(g => g.Name == name);
        }

        public bool Remove(IGun model)
        {
           return this._guns.Remove(model);
        }
    }
}