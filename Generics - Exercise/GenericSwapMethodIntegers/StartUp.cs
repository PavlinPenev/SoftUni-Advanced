using System;
using System.Collections.Generic;
using System.Linq;
using GenericBoxOfString;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> list = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                Box<int> currentBox = new Box<int>(int.Parse(Console.ReadLine()));
                list.Add(currentBox);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(list, indexes[0], indexes[1]);
            Console.WriteLine(string.Join(Environment.NewLine, list));
        }

        static void Swap<T>(List<Box<T>> list, int idx1, int idx2)
        {
            Box<T> temp = list[idx1];
            list[idx1] = list[idx2];
            list[idx2] = temp;
        }
    }
}
