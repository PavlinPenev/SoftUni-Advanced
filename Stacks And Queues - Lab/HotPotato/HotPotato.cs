using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split());
            int tosses = int.Parse(Console.ReadLine());
            while (kids.Count > 1)
            {
                for (int i = 1; i < tosses; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Peek()}");
        }
    }
}
