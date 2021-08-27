using System;
using System.Linq;

namespace CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = i =>
            {
                int min = int.MaxValue;
                for (int j = 0; j < i.Length; j++)
                {
                    if (i[j] < min)
                    {
                        min = i[j];
                    }
                }

                return min;
            };
            Console.WriteLine(min(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()));
        }
    }
}
