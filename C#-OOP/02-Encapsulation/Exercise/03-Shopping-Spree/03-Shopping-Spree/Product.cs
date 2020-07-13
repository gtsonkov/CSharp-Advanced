using System;

namespace _03_Shopping_Spree
{
    public class Product
    {
        private string _name;

        private decimal _cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name 
        {
            get
            {
                return this._name;
            }

            set
            {
                if (value == string.Empty || value == null || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this._name = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return this._cost;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this._cost = value;
            }
        }
    }
}