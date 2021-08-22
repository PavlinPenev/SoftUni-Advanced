using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> doubles = new Dictionary<double, int>();
            double[] valuesForDict = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            foreach (var value in valuesForDict)
            {
                if (!doubles.ContainsKey(value))
                {
                    doubles.Add(value,0);
                }

                doubles[value]++;
            }

            foreach (var @double in doubles)
            {
                Console.WriteLine($"{@double.Key} - {@double.Value} times");
            }
        }
    }
}
