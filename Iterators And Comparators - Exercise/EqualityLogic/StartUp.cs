using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sorted = new SortedSet<Person>(new Comparer());
            HashSet<Person> hash = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = person[0];
                int age = int.Parse(person[1]);
                Person currentPerson = new Person() {Age = age, Name = name};
                sorted.Add(currentPerson);
                hash.Add(currentPerson);
            }

            Console.WriteLine(sorted.Count);
            Console.WriteLine(hash.Count);
        }
    }
}
