using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Football_Team_Generator
{
    public class Team
    {
        private List<Player> _players;
        private string _name;

        public Team(string name)
        {
            this.Name = name;
            this._players = new List<Player>();
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this._name = value;
            }
        }

        public void AddPlayer (Player player)
        {
            if (player != null)
            {
                this._players.Add(player);
            }
        }

        public void RemovePlayer(string playerName)
        {
            var playerToRemove = this._players.FirstOrDefault(x=> x.Name == playerName);
            if (playerToRemove == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this._players.Remove(playerToRemove);
        }

        public int Rating()
        {
            double rating = 0.0;

            if (this._players.Count > 0)
            {
                rating = (((this._players.Select(x => x.SkillLevel).ToArray().Sum()) / this._players.Count));
            }

            return Convert.ToInt32(rating);
        }
    }
}