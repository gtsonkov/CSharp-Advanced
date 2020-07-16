using System;
using System.Collections.Generic;

namespace _04_PizzaCalories
{
    public class Dough
    {
        private const double DefaultCalories = 2.0;
        private const double MIN_WEIGHT = 1.00;
        private const double MAX_WEIGHT = 200.00;

        private readonly Dictionary<string, double> DefaultFlourTypes = new Dictionary<string, double>
        {
            {"white", 1.50 },
            {"wholegrain", 1.0 },
        };

        private readonly Dictionary<string, double> DefaultBakingTechnique = new Dictionary<string, double>
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 },
        };


        private double _weight;
        private string _flourType;
        private string _bakingTechnique;

        public Dough(string flourType, string backingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = backingTechnique;
            this.Weight = weight;
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
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this._weight = value;
            }
        }

        private string FlourType
        {
            get
            {
                return this._flourType;
            }

            set
            {
                if (!DefaultFlourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this._flourType = value.ToLower();
            }
        }

        private string BakingTechnique
        {
            get
            {
                return this._bakingTechnique;
            }

            set
            {
                if (!DefaultBakingTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this._bakingTechnique = value.ToLower();
            }
        }

        public double Calories
        {
            get
            {
                return CalculateCalories();
            }
        }

        private double CalculateCalories()
        {
            return ((DefaultCalories * this.Weight) * this.DefaultFlourTypes[this.FlourType] * this.DefaultBakingTechnique[this.BakingTechnique]);
        }
    }
}