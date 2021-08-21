using System;
using System.Linq;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < row.Length; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (i == j)
                    {
                        sum1 += matrix[i, j];
                    }
                }
            }

            int reverseCounter = matrixSize - 1;
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (j == reverseCounter)
                    {
                        sum2 += matrix[i, j];
                        reverseCounter--;
                        break;
                    }
                }
            }

            Console.WriteLine(Math.Abs(sum1 - sum2));
        }
    }
}
