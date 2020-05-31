using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Cities_by_Contitents_and_Country
{
    class CitiesByContitentsAndCountry
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> db = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (db.ContainsKey(continent))
                {
                    if (db[continent].ContainsKey(country))
                    {
                        db[continent][country].Add(city);
                    }

                    else
                    {
                        List<string> cities = new List<string>();
                        cities.Add(city);
                        db[continent].Add(country, cities);
                    }
                }

                else
                {
                    List<string> cities = new List<string>();
                    cities.Add(city);

                    Dictionary<string, List<string>> currCountry = new Dictionary<string, List<string>>();
                    currCountry.Add(country, cities);

                    db.Add(continent, currCountry);
                }

            }

            foreach (var continent in db)
            {
                Console.WriteLine(continent.Key + ":");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}