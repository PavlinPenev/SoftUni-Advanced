using System;
using System.Linq;

namespace PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Predicate<string> cond = str => str.Length <= n;
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().FindAll(cond).ForEach(Console.WriteLine);
        }
    }
}
