using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Queue<int> bullets = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Reverse());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int intelligenceValue = int.Parse(Console.ReadLine());
            int shotsFiredCounter = 0;
            int shotsFiredTotal = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                bool isDestroyed = false;
                shotsFiredCounter++;
                shotsFiredTotal++;
                if (bullets.Peek() <= locks.Peek())
                {
                    locks.Dequeue();
                    isDestroyed = true;
                }

                bullets.Dequeue();
                Console.WriteLine(isDestroyed ? "Bang!" : "Ping!");
                if (shotsFiredCounter == barrelSize && bullets.Count > 0)
                {
                    shotsFiredCounter = 0;
                    Console.WriteLine("Reloading!");
                }
            }

            int bulletsCost = shotsFiredTotal * bulletPrice;
            int moneyEarned = intelligenceValue - bulletsCost;
            Console.WriteLine(locks.Count == 0 ? $"{bullets.Count} bullets left. Earned ${moneyEarned}" : $"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
