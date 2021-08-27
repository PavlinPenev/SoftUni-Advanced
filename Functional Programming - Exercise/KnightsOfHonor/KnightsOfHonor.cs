using System;
using System.Linq;

namespace KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        { 
            Func<string, string> addPrefix = str => str.Insert(0, "Sir ");
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(addPrefix).ToList().ForEach(Console.WriteLine);
        }
    }
}
