using System;
using System.Linq;

namespace MergeSort
{
    class MergeSort
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            MergeSort<int> sorter = new MergeSort<int>();
            int[] sortedArray = sorter.Sort(array);
            Console.WriteLine(string.Join(" ", sortedArray));
        }
    }

    public class MergeSort<T> where T : IComparable
    {
        public T[] Sort(T[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int splitArray = array.Length / 2;
            T[] left = new T[splitArray];
            T[] right = new T[array.Length - splitArray];
            Array.ConstrainedCopy(array, 0, left, 0, left.Length);
            Array.ConstrainedCopy(array, splitArray, right, 0, right.Length);
            left = Sort(left);
            right = Sort(right);

            T[] sorted = Merge(left, right);
            return sorted;
        }

        public T[] Merge(T[] left, T[] right)
        {
            T[] mergedItems = new T[left.Length + right.Length];

            int leftIdx = 0;
            int rightIdx = 0;

            while (leftIdx < left.Length || rightIdx  < right.Length)
            {
                int mergedIdx = leftIdx + rightIdx;
                if (leftIdx < left.Length && rightIdx < right.Length)
                {
                    bool leftPrecedes = left[leftIdx].CompareTo(right[rightIdx]) < 0;
                    if (leftPrecedes)
                    {
                        mergedItems[mergedIdx] = left[leftIdx++];
                    }
                    else
                    {
                        mergedItems[mergedIdx] = right[rightIdx++];
                    }
                }
                else if (leftIdx < left.Length)
                {
                    mergedItems[mergedIdx] = left[leftIdx++];
                }
                else if (rightIdx < right.Length)
                {
                    mergedItems[mergedIdx] = right[rightIdx++];
                }
            }

            return mergedItems;
        }
    }
}
