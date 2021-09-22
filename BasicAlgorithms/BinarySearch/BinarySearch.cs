using System;
using System.Linq;

namespace BinarySearch
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int searchForItem = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch.IndexOf(array, searchForItem));
        }
    }

    public class BinarySearch
    {
        public static int IndexOf(int[] array, int itemToFind)
        {
            int start = 0;
            int end = array.Length - 1;
            while (start <= end)
            {
                int midPointIdx = (start + end) / 2;
                if (itemToFind < array[midPointIdx])
                {
                    end = midPointIdx - 1;
                }

                else if (itemToFind > array[midPointIdx])
                {
                    start = midPointIdx + 1;
                }
                else
                {
                    return midPointIdx;
                }
            }
            return -1;
        }
    }
}
