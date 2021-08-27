using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvenOrOdds
{
    class FindEvenOrOdds
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            for (int i = boundaries[0]; i <= boundaries[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> cond = null;
            switch (Console.ReadLine())
            {
                case "even":
                    cond = i => i % 2 == 0;
                    break;
                case "odd":
                    cond = i => i % 2 != 0;
                    break;
            }

            Console.WriteLine(string.Join(" ", numbers.FindAll(cond)));
        }
    }
}
