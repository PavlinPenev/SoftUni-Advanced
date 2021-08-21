using System;
using System.Linq;

namespace SquaresInMatrix
{
    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[matrixSizes[0], matrixSizes[1]];
            int counter = 0;
            for (int i = 0; i < matrixSizes[0]; i++)
            {
                string[] row = Console.ReadLine().Split();
                for (int j = 0; j < matrixSizes[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            for (int i = 0; i < matrixSizes[0] - 1; i++)
            {
                for (int j = 0; j < matrixSizes[1] - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
 