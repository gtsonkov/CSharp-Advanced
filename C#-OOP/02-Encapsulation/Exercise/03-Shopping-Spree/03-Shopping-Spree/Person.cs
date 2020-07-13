using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Shopping_Spree
{
    public class Person
    {
        private string _name;

        private decimal _money;

        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this._name;
            }

           private set
            {
                if (value == string.Empty || value == null || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this._name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this._money;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this._money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            string result = "";

            if (product.Cost <= this.Money)
            {
                products.Add(product);

                Money -= product.Cost;

                result = $"{this.Name} bought {product.Name}";
            }
            else
            {
                result = $"{this.Name} can't afford {product.Name}";
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (products.Any())
            {
                sb.AppendLine($"{this.Name} - " + string.Join(", ", products.Select(x=> x.Name).ToArray()));
            }
            else
            {
                sb.AppendLine($"{this.Name} - Nothing bought");
            }

            return sb.ToString()
                .TrimEnd();
        }
    }
}