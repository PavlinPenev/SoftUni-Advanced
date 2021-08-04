using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            //integers[0] - how many enqueues, integers[1] - how many dequeues, integers[2] - which number to look for if the queue contains it.
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            for (int i = 0; i < integers[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count <= 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Contains(integers[2]) ? "true" : $"{queue.Min()}");
            }
        }
    }
}
