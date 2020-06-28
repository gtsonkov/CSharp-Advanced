using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
       private List<Present> data;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }
        public string Color { get; set; }

        public int Capacity { get; set; }

        public void Add (Present present)
        {
            if (this.Capacity > this.Count)
            {
                this.data.Add(present);
            }
            
        }

        public bool Remove (string name)
        {
            Present toRemove = this.data.Where(x => x.Name == name).FirstOrDefault();
            return this.data.Remove(toRemove);
        }

        public Present GetHeaviestPresent()
        {
            Present heaviest = this.data.OrderByDescending(x => x.Weight).FirstOrDefault();
            return heaviest;
        }

        public Present GetPresent(string name)
        {
            Present toReturn = this.data.Where(x => x.Name == name).FirstOrDefault();
            return toReturn;
        }

        public int Count => this.data.Count();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}