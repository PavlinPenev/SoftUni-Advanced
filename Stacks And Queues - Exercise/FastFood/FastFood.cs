using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int qtyFood = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int biggestOrder = orders.Max();
            int count = orders.Count;
            for (int i = 0; i < count; i++)
            {
                if (qtyFood >= orders.Peek())
                {
                    qtyFood -= orders.Dequeue();
                }
            }
            Console.WriteLine(biggestOrder);

            Console.WriteLine(orders.Count <= 0 ? "Orders complete" : $"Orders left: {string.Join(" ", orders)}");
        }
    }
}
