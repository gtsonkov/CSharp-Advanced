using System;
using System.Collections.Generic;

namespace _04_PizzaCalories
{
    public class Pizza
    {
        private const int MAX_NAME_LENGHT = 15;
        private const int MIN_NAME_LENGHT = 1;
        private const int MAX_TOPPINGS_COUNT = 10;
        private const int MIN_TOPPINGS_COUNT = 0;
        private string _name;
        private Dough _dought;

        List<Topping> _toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this._toppings = new List<Topping>();
        }

        public Dough Dough 
        { 
           private get
            {
                return this._dought;
            }
            set
            {
                if (value != null)
                {
                    this._dought = value;
                }
            }
        }

        private string Name
        {
            get
            {
                return this._name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty || value.Length > MAX_NAME_LENGHT || value.Length < MIN_NAME_LENGHT)
                {
                    throw new ArgumentException($"Pizza name should be between {MIN_NAME_LENGHT} and {MAX_NAME_LENGHT} symbols.");
                }

                this._name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this._toppings.Count >= MAX_TOPPINGS_COUNT)
            {
                throw new ArgumentException($"Number of toppings should be in range [{MIN_TOPPINGS_COUNT}..{MAX_TOPPINGS_COUNT}].");
            }

            this._toppings.Add(topping);
        }

        public double TotalCalories => this.CalculateCalories();

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }

        private double CalculateCalories()
        {
            double result = 0;

            result += this.Dough.Calories;

            foreach (var t in this._toppings)
            {
                result += t.Calories;
            }

            return result;
        }
    }
}