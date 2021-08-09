using System;
using System.Linq;

namespace SumMatrixColumns
{
    class SumMatrixColumns
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];
            for (int i = 0; i < matrixSizes[0]; i++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrixSizes[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            for (int i = 0; i < matrixSizes[1]; i++)
            {
                int columnSum = 0;
                for (int j = 0; j < matrixSizes[0]; j++)
                {
                    columnSum += matrix[j, i];
                }

                Console.WriteLine(columnSum);
            }
        }
    }
}
