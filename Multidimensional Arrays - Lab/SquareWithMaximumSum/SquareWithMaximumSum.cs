using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];
            int[,] matrix2x2 = new int[2, 2];
            int biggestSum = 0;
            for (int i = 0; i < matrixSizes[0]; i++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < matrixSizes[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            for (int i = 0; i < matrixSizes[0] - 1; i++)
            {
                for (int j = 0; j < matrixSizes[1] - 1; j++)
                {
                    if (matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1] > biggestSum)
                    {
                        biggestSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                        matrix2x2[0, 0] = matrix[i, j];
                        matrix2x2[0, 1] = matrix[i, j + 1];
                        matrix2x2[1, 0] = matrix[i + 1, j];
                        matrix2x2[1, 1] = matrix[i + 1, j + 1];
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(matrix2x2[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(biggestSum);
        }
    }
}
