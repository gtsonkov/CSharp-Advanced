using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Shopping_Spree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peoples = Console.ReadLine().Split(";").ToArray();
            string[] productsList = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries).ToArray();
            try
            {
                GetPersonsFromInput(peoples, persons);
                GetProductsFromInput(productsList, products);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }
            

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "END")
            {
                var currPerson = persons.Where(x => x.Name == command[0]).FirstOrDefault();
                var currProduct = products.Where(x => x.Name == command[1]).FirstOrDefault();

                Console.WriteLine(currPerson.BuyProduct(currProduct));

                command = Console.ReadLine().Split().ToArray();
            }

            foreach (var p in persons)
            {
                Console.WriteLine(p.ToString());
            }
        }

        private static void GetPersonsFromInput(string[] names, List<Person> persons)
        {
            foreach (var p in names)
            {
                string[] currPerson = p.Split("=").ToArray();
                string name = currPerson[0];
                decimal money = decimal.Parse(currPerson[1]);

                try
                {
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        private static void GetProductsFromInput(string[] names, List<Product> products)
        {
            foreach (var p in names)
            {
                string[] currPerson = p.Split("=").ToArray();
                string name = currPerson[0];
                decimal money = decimal.Parse(currPerson[1]);

                try
                {
                    Product person = new Product(name, money);
                    products.Add(person);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }
    }
}