using System;
using System.Buffers;
using System.Linq;

namespace QuickSort
{
    class QuickSort
    {
        static void Main(string[] args)
        {
            long[] array = Console.ReadLine().Split().Select(long.Parse).ToArray();
            Quick.Sort(array);
            Console.WriteLine(string.Join(" ", array));
        }
    }

    public class Quick
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            Shuffle(array);
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int start, int end) where T : IComparable
        {
            if (start >= end)
            {
                return;
            }

            int pivotIdx = Partition(array, start, end);
            Sort(array, start, pivotIdx - 1);
            Sort(array, pivotIdx + 1, end);
        }

        private static int Partition<T>(T[] array, int start, int end) where T : IComparable
        {
            if (start >= end)
            {
                return start;
            }

            int i = start;
            int j = end + 1;
            while (true)
            {
                
                while (Less(array[++i],array[start]))
                {
                    if (i == end)
                    {
                        break;
                    }
                }

                while (Less(array[start], array[--j]))
                {
                    if (j == start)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }

                Swap(array, i, j);
            }

            Swap(array, start, j);
            return j;
        }
        private static bool Less<T>(T current, T other) where T : IComparable
        {
            return current.CompareTo(other) < 0;
        }

        private static void Swap<T>(T[] array, int itemIdx, int item1Idx)
        {
            T temp = array[itemIdx];
            array[itemIdx] = array[item1Idx];
            array[item1Idx] = temp;
        }
        private static void Shuffle<T>(T[] array)
        {
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int r = i + rnd.Next(0, array.Length - i);

                T temp = array[i];
                array[i] = array[r];
                array[r] = temp;
            }
        }
    }
}
