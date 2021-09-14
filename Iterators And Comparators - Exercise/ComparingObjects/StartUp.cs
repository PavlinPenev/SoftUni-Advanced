using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            int matchesCount = 0;
            int countRestPeople = 0;
            List<Person> people = new List<Person>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person currentPerson = new Person(info[0], int.Parse(info[1]), info[2]);
                people.Add(currentPerson);
            }

            int n = int.Parse(Console.ReadLine());
            
            if (people.Count > n)
            {
                Person filterPerson = people[n - 1];
                foreach (var person in people)
                {
                    if (filterPerson.CompareTo(person) == 0)
                    {
                        matchesCount++;
                    }
                    else
                    {
                        countRestPeople++;
                    }
                }
            }
            Console.WriteLine(matchesCount > 0 ? $"{matchesCount} {countRestPeople} {people.Count}" : "No matches");
        }
    }
}
