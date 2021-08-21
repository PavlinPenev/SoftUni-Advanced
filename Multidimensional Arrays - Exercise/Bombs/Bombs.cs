using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            Queue<Tuple<int, int>> bombAOE = new Queue<Tuple<int, int>>();
            bombAOE.Enqueue(new Tuple<int, int>(-1, -1));
            bombAOE.Enqueue(new Tuple<int, int>(-1, 0));
            bombAOE.Enqueue(new Tuple<int, int>(-1, 1));
            bombAOE.Enqueue(new Tuple<int, int>(0, 1));
            bombAOE.Enqueue(new Tuple<int, int>(1, 1));
            bombAOE.Enqueue(new Tuple<int, int>(1, 0));
            bombAOE.Enqueue(new Tuple<int, int>(1, -1));
            bombAOE.Enqueue(new Tuple<int, int>(0, -1));

            int matrixSize = int.Parse(Console.ReadLine());
            long[,] matrix = new long[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                int[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var coordinate in coordinates)
            {
                int[] bombIndeces = coordinate.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int idxRow = bombIndeces[0];
                int idxCol = bombIndeces[1];
                if (matrix[idxRow, idxCol] > 0)
                {
                    for (int i = 1; i <= bombAOE.Count; i++)
                    {
                        int idxRowAOE = bombAOE.Peek().Item1;
                        int idxColAOE = bombAOE.Peek().Item2;
                        bombAOE.Enqueue(bombAOE.Dequeue());
                        try
                        {
                            if (matrix[idxRow + idxRowAOE, idxCol + idxColAOE] > 0)
                            {
                                matrix[idxRow + idxRowAOE, idxCol + idxColAOE] -= matrix[idxRow, idxCol];
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    matrix[idxRow, idxCol] = 0;
                }
            }
            var query = from long i in matrix
                        where i > 0
                        select i;
            Console.WriteLine($"Alive cells: {query.Count()}");
            Console.WriteLine($"Sum: {query.Sum()}");
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
