using System;
using System.Linq;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];
            int[,] matrix3x3 = new int[3, 3];
            int sum = int.MinValue;
            for (int i = 0; i < matrixSizes[0]; i++)
            {
                int[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrixSizes[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            for (int i = 0; i < matrixSizes[0] - 2; i++)
            {
                for (int j = 0; j < matrixSizes[1] - 2; j++)
                {
                    if (matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2] > sum)
                    {
                        sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] +
                              matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] +
                              matrix[i + 2, j + 2];
                        matrix3x3[0, 0] = matrix[i, j];
                        matrix3x3[0, 1] = matrix[i, j + 1];
                        matrix3x3[0, 2] = matrix[i, j + 2];
                        matrix3x3[1, 0] = matrix[i + 1, j];
                        matrix3x3[1, 1] = matrix[i + 1, j + 1];
                        matrix3x3[1, 2] = matrix[i + 1, j + 2];
                        matrix3x3[2, 0] = matrix[i + 2, j];
                        matrix3x3[2, 1] = matrix[i + 2, j + 1];
                        matrix3x3[2, 2] = matrix[i + 2, j + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix3x3[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
