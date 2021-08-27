using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = person[0];
                int age = int.Parse(person[1]);
                people.Add(name, age);
            }
            Func<int, int, bool> cond = null;
            switch (Console.ReadLine())
            {
                case "older": 
                    cond = (i, j) => i >= j;
                    break;
                case "younger":
                    cond = (i, j) => i < j;
                    break;
            }

            int ageFilter = int.Parse(Console.ReadLine());
            string filter = Console.ReadLine();
            switch (filter)
            {
                case "name":
                    foreach (var person in people.Where(p => cond(p.Value, ageFilter)))
                    {
                        Console.WriteLine(person.Key);
                    }

                    break;
                case "age":
                    foreach (var person in people.Where(p => cond(p.Value, ageFilter)))
                    {
                        Console.WriteLine(person.Value);
                    }

                    break;
                case "name age":
                    foreach (var person in people.Where(p => cond(p.Value, ageFilter)))
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }

                    break;
            }
        }
    }
}
