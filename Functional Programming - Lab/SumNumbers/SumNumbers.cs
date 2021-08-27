using System;
using System.Linq;

namespace SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(input.Length);
            Console.WriteLine(input.Sum());
        }
    }
}
