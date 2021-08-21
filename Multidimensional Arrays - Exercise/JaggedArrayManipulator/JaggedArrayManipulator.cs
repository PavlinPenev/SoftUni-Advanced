using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class JaggedArrayManipulator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArr = new double[n][];
            for (int i = 0; i < n; i++)
            {
                double[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jaggedArr[i] = row.ToArray();
            }

            for (int i = 0; i < jaggedArr.Length - 1; i++)
            {
                if (jaggedArr[i].Length == jaggedArr[i + 1].Length)
                {
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        jaggedArr[i][j] *= 2;
                        jaggedArr[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        jaggedArr[i][j] /= 2;
                    }

                    for (int j = 0; j < jaggedArr[i + 1].Length; j++)
                    {
                        jaggedArr[i + 1][j] /= 2;
                    }
                }
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Add":
                        int row = int.Parse(command[1]);
                        int col = int.Parse(command[2]);
                        double value = int.Parse(command[3]);
                        if (row >= 0 && row <= jaggedArr.Length - 1)
                        {
                            if (col >= 0 && col <= jaggedArr[row].Length - 1)
                            {
                                jaggedArr[row][col] += value;
                            }
                        }
                        break;
                    case "Subtract":
                        row = int.Parse(command[1]);
                        col = int.Parse(command[2]);
                        value = int.Parse(command[3]);
                        if (row >= 0 && row <= jaggedArr.Length - 1)
                        {
                            if (col >= 0 && col <= jaggedArr[row].Length - 1)
                            {
                                jaggedArr[row][col] -= value;
                            }
                        }
                        break;
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[i]));
            }
        }
    }
}
