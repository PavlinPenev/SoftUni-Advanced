using System;
using System.Linq;

namespace RecursiveArraySum
{
    class RecursiveArraySum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int currentIdx = 0;
            int sum = 0;
            Console.WriteLine(Sum(array, currentIdx, sum));
        }

        private static int Sum(int[] array, int idx, int sum)
        {
            if (idx == array.Length)
            {
                return sum;
            }
            sum += array[idx];
            idx++;
            
            return Sum(array, idx, sum);
        }
    }
}
