using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            Stack<int> integers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            string[] command = Console.ReadLine().ToLower().Split();
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "add":
                        integers.Push(int.Parse(command[1]));
                        integers.Push(int.Parse(command[2]));
                        break;
                    case "remove":
                        int n = int.Parse(command[1]);
                        if (n <= integers.Count)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                integers.Pop();
                            }
                        }

                        break;
                }
                command = Console.ReadLine().ToLower().Split();
            }

            Console.WriteLine($"Sum: {integers.Sum()}");
        }
    }
}
