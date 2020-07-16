using System;
using System.Collections.Generic;

namespace _04_PizzaCalories
{
    public class Topping
    {
        private const double DefaultCalories = 2.0;

        private readonly Dictionary<string, double> DefaultToppingTypes = new Dictionary<string, double>
        {
            {"Meat", 1.20 },
            {"Veggies", 0.80 },
            {"Cheese", 1.10 },
            {"Sauce", 0.90 },
        };

        private double _weight;
        private string _toppigType;

        public string ToppigName 
        { 
            get
            {
               return this._toppigType;
            }
            set
            {
                if (!this.DefaultToppingTypes.ContainsKey(value))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this._toppigType = value;
            }
        }

        public double Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppigName} weight should be in the range[1..50].");
                }

                this._weight = value;
            }
        }
    }
}