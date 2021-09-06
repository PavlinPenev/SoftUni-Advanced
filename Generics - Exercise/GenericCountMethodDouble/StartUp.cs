using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDouble
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> doubles = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                Box<double> currentBox = new Box<double>(double.Parse(Console.ReadLine()));
                doubles.Add(currentBox);
            }

            Console.WriteLine(FilterCount(doubles, double.Parse(Console.ReadLine())));
        }
        static int FilterCount<T>(List<Box<T>> list, T item) where T : IComparable
            => list.Count(b => b.Value.CompareTo(item) > 0);
    }
}
