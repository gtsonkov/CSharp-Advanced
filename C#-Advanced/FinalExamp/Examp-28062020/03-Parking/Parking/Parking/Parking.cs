using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (this.Capacity > this.Count)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = this.data
                .Where(x => x.Manufacturer == manufacturer
                && x.Model == model)
                .FirstOrDefault();

            return this.data.Remove(carToRemove);
        }

        public Car GetLatestCar()
        {
            Car carToReturn = this.data
                .OrderByDescending(x => x.Year)
                .FirstOrDefault();

            return carToReturn;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car carToReturn = this.data
               .Where(x => x.Manufacturer == manufacturer
               && x.Model == model)
               .FirstOrDefault();

            return carToReturn;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var c in this.data)
            {
                sb.AppendLine(c.ToString());
            }

            return sb.ToString()
                .TrimEnd();
        }
    }
}