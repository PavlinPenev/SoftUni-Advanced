using System;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Age.CompareTo(other.Age) != 0)
            {
                return this.Age.CompareTo(other.Age);
            }

            if (this.Town.CompareTo(other.Town) != 0)
            {
                return this.Town.CompareTo(other.Town);
            }

            return 0;
        }
    }
}
