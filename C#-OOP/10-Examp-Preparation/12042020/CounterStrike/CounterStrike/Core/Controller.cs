using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private IRepository<IGun> _guns;
        private IRepository<IPlayer> _players;
        private IMap _map;
        private readonly List<string> _gunTypes;
        private readonly List<string> _playerTypes;


        public Controller()
        {
            this._guns = new GunRepository();
            this._players = new PlayerRepository();
            this._map = new Map();
            this._gunTypes = new List<string>();
            this._playerTypes = new List<string>();

            SeedPlayerTypes();
            SeedGunTypes();
        }

       

        public string AddGun(string type, string name, int bulletsCount)
        {
            if (!this._gunTypes.Contains(type))
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            IGun currGun = null;

            switch (type)
            {
                case "Pistol":
                    currGun = new Pistol(name,bulletsCount);

                    break;

                case "Rifle":
                    currGun = new Rifle(name, bulletsCount);

                    break;
            }

            if (this._guns.Models.Any(g => g.Name == name))
            {
                return null;
            }

            this._guns.Add(currGun);

            return $"Successfully added gun {currGun.Name}.";
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun currGun = this._guns.FindByName(gunName);

            if (currGun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (!this._playerTypes.Contains(type))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            IPlayer currPlayer = null;

            switch (type)
            {
                case "Terrorist":
                    currPlayer = new Terrorist(username, health, armor, currGun);
                    break;

                case "CounterTerrorist":
                    currPlayer = new CounterTerrorist(username, health, armor, currGun);
                    break;
            }

            if (this._players.Models.Any(p => p.Username == username))
            {
                return null;
            }

            this._players.Add(currPlayer);

            return $"Successfully added player {currPlayer.Username}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this._players.Models
                                                .OrderBy(p => p.GetType().Name)
                                                .ThenByDescending(p => p.Health)
                                                .ThenBy(p => p.Username))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            List<IPlayer> players = new List<IPlayer>();

            foreach (var player in this._players.Models)
            {
                players.Add(player);
            }

            var result = this._map.Start(players);

            return result;
        }

        private void SeedGunTypes()
        {
            foreach (var t in Assembly.GetAssembly(typeof(Gun)).GetTypes()
                .Where(ty => ty.IsSubclassOf(typeof(Gun))))
            {
                this._gunTypes.Add(t.Name);
            }
        }

        private void SeedPlayerTypes()
        {
            foreach (var t in Assembly.GetAssembly(typeof(Player)).GetTypes()
                .Where(ty => ty.IsSubclassOf(typeof(Player))))
            {
                this._playerTypes.Add(t.Name);
            }
        }
    }
}