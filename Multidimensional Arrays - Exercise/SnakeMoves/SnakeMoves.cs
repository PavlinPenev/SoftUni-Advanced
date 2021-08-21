using System;
using System.Linq;
using System.Text;

namespace SnakeMoves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            StringBuilder snake = new StringBuilder(Console.ReadLine());
            string snakeTemp = snake.ToString();
            char[,] snakePath = new char[matrixSizes[0], matrixSizes[1]];
            for (int i = 0; i < matrixSizes[0]; i++)
            {
                if (i%2 == 0)
                {
                    for (int j = 0; j < matrixSizes[1]; j++)
                    {
                        if (snake.Length == 0)
                        {
                            snake.Append(snakeTemp);
                        }
                        snakePath[i, j] = snake[0];
                        snake.Remove(0, 1);
                    }
                }
                else
                {
                    for (int j = matrixSizes[1] - 1; j >= 0; j--)
                    {
                        if (snake.Length == 0)
                        {
                            snake.Append(snakeTemp);
                        }
                        snakePath[i, j] = snake[0];
                        snake.Remove(0, 1);
                    }
                }
            }

            for (int i = 0; i < matrixSizes[0]; i++)
            {
                for (int j = 0; j < matrixSizes[1]; j++)
                {
                    Console.Write(snakePath[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
