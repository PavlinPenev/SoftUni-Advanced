using System;
using System.Linq;

namespace AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList().ForEach(n => Console.WriteLine($"{n * 1.20:f2}"));
        }
    }
}
