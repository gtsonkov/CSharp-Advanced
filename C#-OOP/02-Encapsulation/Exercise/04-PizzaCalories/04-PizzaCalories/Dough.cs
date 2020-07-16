using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _04_PizzaCalories
{
    public class Dough
    {
        private const double DefaultCalories = 2.0;

        private readonly Dictionary<string, double> DefaultFlourTypes = new Dictionary<string, double>
        {
            {"White", 1.50 },
            {"Wholegrain", 1.0 },
        };

        private readonly Dictionary<string, double> DefaultBakingTechnique = new Dictionary<string, double>
        {
            {"Crispy", 0.9 },
            {"Chewy", 1.1 },
            {"Homemade", 1.0 },
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

        public double Weight 
        { 
            get
            {
                return this._weight;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this._weight = value;
            }
        }

        public string FlourType
        {
            get
            {
                return this._flourType;
            }
            set
            {
                if (!DefaultFlourTypes.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this._flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this._bakingTechnique;
            }
            set
            {
                if (!DefaultBakingTechnique.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this._bakingTechnique = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                return CalculateCaloriesPerGram();
            }
        }

        private double CalculateCaloriesPerGram()
        {
            return ((DefaultCalories * this.Weight) * this.DefaultFlourTypes[this.FlourType] * this.DefaultBakingTechnique[this.BakingTechnique]);
        }
    }
}