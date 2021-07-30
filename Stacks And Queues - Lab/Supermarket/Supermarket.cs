using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Supermarket
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            string customer = Console.ReadLine();
            while (customer != "End")
            {
                if (customer == "Paid")
                {
                    foreach (var customer1 in customers)
                    {
                        Console.WriteLine(customer1);
                    }
                    customers.Clear();
                    customer = Console.ReadLine();
                    continue;
                }

                customers.Enqueue(customer);
                customer = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
