using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            Action<List<int>> add = i =>
            {
                for (int j = 0; j < i.Count; j++)
                {
                    i[j]++;
                }
            };
            Action<List<int>> multiply = i => 
            {
                for (int j = 0; j < i.Count; j++)
                {
                    i[j] *= 2;
                }
            };
            Action<List<int>> subtract = i =>
            {
                for (int j = 0; j < i.Count; j++)
                {
                    i[j]--;
                }
            };
            Action<List<int>> print = i => Console.WriteLine(string.Join(" ", i));
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        add(numbers);
                        break;
                    case "subtract":
                        subtract(numbers);
                        break;
                    case "multiply":
                        multiply(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}
