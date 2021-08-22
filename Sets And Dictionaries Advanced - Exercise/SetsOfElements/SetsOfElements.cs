using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            HashSet<string> first = new HashSet<string>();
            HashSet<string> second = new HashSet<string>();
            int[] iterations = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < iterations[0]; i++)
            {
                first.Add(Console.ReadLine());
            }

            for (int i = 0; i < iterations[1]; i++)
            {
                second.Add(Console.ReadLine());
            }

            first.IntersectWith(second);
            Console.WriteLine(string.Join(" ", first));
        }
    }
}
