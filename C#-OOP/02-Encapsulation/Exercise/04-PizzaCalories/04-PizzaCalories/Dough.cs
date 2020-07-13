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


        private double weight;
        private string flourType;
        private string bakingTechnique;

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }
    }
}