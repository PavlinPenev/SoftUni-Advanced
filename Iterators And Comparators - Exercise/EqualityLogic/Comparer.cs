using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityLogic
{
    public class Comparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.CompareTo(y.Name) != 0)
            {
                return x.Name.CompareTo(y.Name);
            }

            if (x.Age.CompareTo(y.Age) != 0)
            {
                return x.Age.CompareTo(y.Age);
            }

            return 0;
        }
    }
}
