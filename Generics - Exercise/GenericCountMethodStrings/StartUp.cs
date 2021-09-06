using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> strings = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                Box<string> currentBox = new Box<string>(Console.ReadLine());
                strings.Add(currentBox);
            }

            Console.WriteLine(FilterCount(strings, Console.ReadLine()));
        }
        static int FilterCount<T>(List<Box<T>> list, T item) where T : IComparable
            => list.Count(b => b.Value.CompareTo(item) > 0);
    }
}
