using System;
using System.Linq;

namespace ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToArray();
            for (int i = 0; i < n; i++)
            {
                array[i] = i + 1;
            }

            int[] finalArray = Array.FindAll(array, i =>
            {
                bool dividable = false;
                for (int j = 0; j < dividers.Length; j++)
                {
                    if (i % dividers[j] == 0)
                    {
                        dividable = true;
                    }

                    if (dividable && i % dividers[j] != 0)
                    {
                        dividable = false;
                        break;
                    }
                }

                return dividable;
            });
            Console.WriteLine(string.Join(" ", finalArray));
        }
    }
}
