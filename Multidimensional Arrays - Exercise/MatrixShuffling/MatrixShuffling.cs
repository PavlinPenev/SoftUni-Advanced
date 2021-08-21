using System;
using System.Linq;

namespace MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[matrixSizes[0], matrixSizes[1]];
            FillMatrix(matrixSizes, matrix);

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "swap":
                        if (command.Length != 5)
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                        int row1Idx = int.Parse(command[1]);
                        int col1Idx = int.Parse(command[2]);
                        int row2Idx = int.Parse(command[3]);
                        int col2Idx = int.Parse(command[4]);
                        if (IdxValidation(row1Idx, matrixSizes[0]) && IdxValidation(col1Idx, matrixSizes[1]) && IdxValidation(row2Idx, matrixSizes[0]) && IdxValidation(col2Idx, matrixSizes[1]))
                        {
                            string temp = matrix[row1Idx, col1Idx];
                            matrix[row1Idx, col1Idx] = matrix[row2Idx, col2Idx];
                            matrix[row2Idx, col2Idx] = temp;
                            PrintMatrix(matrixSizes, matrix);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            }
        }

        private static void PrintMatrix(int[] matrixSizes, string[,] matrix)
        {
            for (int i = 0; i < matrixSizes[0]; i++)
            {
                for (int j = 0; j < matrixSizes[1]; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IdxValidation(int row1Idx, int matrixSizes)
        {
            if (row1Idx >= 0 && row1Idx < matrixSizes)
            {
                return true;
            }

            return false;
        }

        private static void FillMatrix(int[] matrixSizes, string[,] matrix)
        {
            for (int i = 0; i < matrixSizes[0]; i++)
            {
                string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrixSizes[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }
    }
}
