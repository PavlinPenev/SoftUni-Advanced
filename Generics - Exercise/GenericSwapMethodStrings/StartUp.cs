using System;
using System.Collections.Generic;
using System.Linq;
using GenericBoxOfString;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> list = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                Box<string> currentBox = new Box<string>(Console.ReadLine());
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
