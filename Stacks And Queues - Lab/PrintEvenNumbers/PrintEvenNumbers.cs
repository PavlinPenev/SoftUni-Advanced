using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class PrintEvenNumbers
    {
        static void Main(string[] args)
        {
            Queue<int> input = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Reverse());

            while (!input.All(i => i % 2 == 0))
            {
                if (input.Peek() % 2 == 0)
                {
                    input.Enqueue(input.Dequeue());
                }
                else
                {
                    input.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", input.Reverse()));
        }
    }
}
