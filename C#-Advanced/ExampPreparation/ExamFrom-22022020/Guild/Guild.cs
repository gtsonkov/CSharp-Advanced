using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.Count)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = this.roster.Where(x => x.Name == name).FirstOrDefault();

            return this.roster.Remove(playerToRemove);
        }

        public void PromotePlayer(string name)
        {
            //Player player = 
            
            //int index = this.roster.IndexOf(player);
            if (this.roster.Where(x => x.Name == name).FirstOrDefault().Rank != "Member")
            {
                this.roster.Where(x => x.Name == name).FirstOrDefault().Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            //Player player = 

            //int index = this.roster.IndexOf(player);
            if (this.roster.Where(x => x.Name == name).FirstOrDefault().Rank != "Trial")
            {
                this.roster.Where(x => x.Name == name).FirstOrDefault().Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string _class)
        {
            Player[] playersToKick = this.roster.Where(x => x.Class == _class).ToArray();

            foreach (var p in playersToKick)
            {
                this.roster.Remove(p);
            }

            return playersToKick;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var p in this.roster)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}