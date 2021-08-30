using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //This code combines all the tasks of the contest from 1st to 4th. The Repository contains zip files with the files for each task separately :)
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] member = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person currentPerson = new Person(int.Parse(member[1]), member[0]);
                family.AddMember(currentPerson);
            }

            family.FamilyMembers.Where(m => m.Age > 30).OrderBy(m => m.Name).ToList().ForEach(Console.WriteLine);
        }
    }
}
