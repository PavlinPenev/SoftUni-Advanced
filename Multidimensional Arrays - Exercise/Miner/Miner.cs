using System;
using System.Linq;

namespace Miner
{
    class Miner
    {
        static void Main(string[] args)
        {
            long fieldSize = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[fieldSize, fieldSize];
            int[] minerIndexes = new int[2];
            int coalCounter = 0;
            for (int i = 0; i < fieldSize; i++)
            {
                string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < fieldSize; j++)
                {
                    field[i, j] = char.Parse(row[j]);
                }
            }

            
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (field[i, j] == 's')
                    {
                        minerIndexes[0] = i;
                        minerIndexes[1] = j;
                    }
                }
            }

            foreach (var c in command)
            {
                switch (c)
                {
                    case "up":
                        minerIndexes[0] -= 1;
                        if (minerIndexes[0] < 0)
                        {
                            minerIndexes[0] += 1;
                        }
                        break;
                    case "down":
                        minerIndexes[0] += 1;
                        if (minerIndexes[0] >= field.GetLength(0))
                        {
                            minerIndexes[0] -= 1;
                        }
                        break;
                    case "left":
                        minerIndexes[1] -= 1;
                        if (minerIndexes[1] < 0)
                        {
                            minerIndexes[1] += 1;
                        }
                        break;
                    case "right":
                        minerIndexes[1] += 1;
                        if (minerIndexes[1] >= field.GetLength(1))
                        {
                            minerIndexes[1] -= 1;
                        }
                        break;
                }
                if (field[minerIndexes[0], minerIndexes[1]] == 'c')
                {
                    coalCounter++;
                    field[minerIndexes[0], minerIndexes[1]] = '*';
                    var query = from char element in field where element == 'c' select element;
                    if (!query.Any())
                    {
                        Console.WriteLine($"You collected all coals! ({minerIndexes[0]}, {minerIndexes[1]})");
                        return;
                    }
                }
                else if (field[minerIndexes[0], minerIndexes[1]] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerIndexes[0]}, {minerIndexes[1]})");
                    return;
                }
            }

            var coals = from char element in field where element == 'c' select element;
            Console.WriteLine($"{coals.Count()} coals left. ({minerIndexes[0]}, {minerIndexes[1]})");
        }
    }
}
