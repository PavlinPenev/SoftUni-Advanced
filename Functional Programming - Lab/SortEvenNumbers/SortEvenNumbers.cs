using System;
using System.Linq;

namespace SortEvenNumbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(n => n % 2 == 0).OrderBy(n => n).ToArray()));
        }
    }
}
