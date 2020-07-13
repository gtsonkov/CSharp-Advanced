using System;
using System.Collections.Generic;

namespace _04_PizzaCalories
{
    public class Dough
    {
        private const double DefaultCalories = 2.0;

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
            FlourType = flourType;
            BakingTechnique = backingTechnique;
            _weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this._flourType;
            }
            set
            {
                //TO DO Validation
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
                //TO DO Validation
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
            throw new NotImplementedException();
        }
    }
}