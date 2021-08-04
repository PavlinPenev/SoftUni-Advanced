using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class MaximumAndMinimumElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> integers = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (command[0])
                {
                    case "1":
                        integers.Push(int.Parse(command[1]));
                        break;
                    case "2":
                        if (integers.Any())
                        {
                            integers.Pop();
                        }
                        break;
                    case "3":
                        if (integers.Count > 0)
                        {
                            Console.WriteLine(integers.Max());
                        }
                        break;
                    case "4":
                        if (integers.Count > 0)
                        {
                            Console.WriteLine(integers.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
