using System;

namespace PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[n][];
            for (int i = 0; i < n; i++)
            {
                long[] row = new long[i + 1];
                row[0] = 1;
                row[i] = 1;
                for (int j = 1; j < i; j++)
                {
                    row[j] = pascalTriangle[i - 1][j] + pascalTriangle[i - 1][j - 1];
                }

                pascalTriangle[i] = row;
                Console.WriteLine(string.Join(" ", pascalTriangle[i]));
            }
        }
    }
}
