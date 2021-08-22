using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Country>> continents = new Dictionary<string, List<Country>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cont = info[0];
                string country = info[1];
                string city = info[2];
                Country currentCountry = new Country(country);
                currentCountry.Cities = new List<string>();
                if (!continents.ContainsKey(cont))
                {
                    continents.Add(cont, new List<Country>());
                }

                int idx = continents[cont].FindIndex(c => c.Name == country);
                if (idx == -1)
                {
                    currentCountry.Cities.Add(city);
                    continents[cont].Add(currentCountry);
                }
                else
                {
                    continents[cont][idx].Cities.Add(city);
                }
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                Console.WriteLine(string.Join(Environment.NewLine, continent.Value));
            }
        }
    }

    class Country
    {
        public Country(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public List<string> Cities { get; set; }
        public override string ToString()
        {
            return $"  {Name} -> {string.Join(", ", Cities)}";
        }
    }
}
