using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private readonly ICollection<Terrorist> _terrorists;
        private readonly ICollection<CounterTerrorist> _counterTerrorists;

        public Map()
        {
            this._terrorists = new List<Terrorist>();

            this._counterTerrorists = new List<CounterTerrorist>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player.GetType() == typeof(Terrorist))
                {
                    this._terrorists.Add((Terrorist)player);
                }
                else
                {
                    this._counterTerrorists.Add((CounterTerrorist)player);
                }
            }

            while (_terrorists.Any(t => t.IsAlive) && _counterTerrorists.Any(ct => ct.IsAlive))
            {
                foreach (var t in this._terrorists.Where(te => te.IsAlive))
                {
                    foreach (var ct in this._counterTerrorists.Where(ctt => ctt.IsAlive))
                    {
                        ct.TakeDamage(t.Gun.Fire());
                    }
                }

                foreach (var ct in this._counterTerrorists.Where(ctt => ctt.IsAlive))
                {
                    foreach (var t in this._terrorists.Where(te => te.IsAlive))
                    {
                        t.TakeDamage(ct.Gun.Fire());
                    }
                }
            }

            string result = string.Empty;

            if (_terrorists.Any(t => t.IsAlive))
            {
                result = "Terrorist wins!";
            }
            else
            {
                result = "Counter Terrorist wins!";
            }

            return result;
        }
    }
}