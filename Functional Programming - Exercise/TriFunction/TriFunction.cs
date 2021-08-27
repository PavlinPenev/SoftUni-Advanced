using System;
using System.Linq;

namespace TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int treshold = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(names.First(n => n.Select(c => (int)c).Sum() >= treshold));
        }
    }
}
