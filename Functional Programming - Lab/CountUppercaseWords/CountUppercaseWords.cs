using System;
using System.Linq;

namespace CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(c => char.IsUpper(c[0])).ToList().ForEach(Console.WriteLine);
        }
    }
}
