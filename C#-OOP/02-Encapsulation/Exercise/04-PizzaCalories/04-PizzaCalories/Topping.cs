using System;
using System.Collections.Generic;

namespace _04_PizzaCalories
{
    public class Topping
    {
        private const double DefaultCalories = 2.0;
        private const double MIN_WEIGHT = 1.00;
        private const double MAX_WEIGHT = 50.00;

        private readonly Dictionary<string, double> DefaultToppingTypes = new Dictionary<string, double>
        {
            {"meat", 1.20 },
            {"veggies", 0.80 },
            {"cheese", 1.10 },
            {"sauce", 0.90 },
        };

        private double _weight;
        private string _toppigType;

        public Topping(string toppingName, double weight)
        {
            this.ToppigName = toppingName;
            this.Weight = weight;
        }

        private string ToppigName
        {
            get
            {
                return this._toppigType;
            }

            set
            {
                if (!this.DefaultToppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this._toppigType = value;
            }
        }

        private double Weight
        {
            get
            {
                return this._weight;
            }

            set
            {
                if (value < MIN_WEIGHT || value > MAX_WEIGHT)
                {
                    throw new ArgumentException($"{this.ToppigName} weight should be in the range[1..50].");
                }

                this._weight = value;
            }
        }

        public double Calories => this.CalculateCalories();

        private double CalculateCalories()
        {
            return ((DefaultCalories * this.Weight) * DefaultToppingTypes[this.ToppigName.ToLower()]);
        }
    }
}