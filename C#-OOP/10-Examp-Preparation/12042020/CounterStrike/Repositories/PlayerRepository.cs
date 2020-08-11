using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> _players;

        public PlayerRepository()
        {
            this._players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models
        {
            get
            {
                return this._players;
            }
        }

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this._players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return this._players.FirstOrDefault(p => p.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            return this._players.Remove(model);
        }
    }
}