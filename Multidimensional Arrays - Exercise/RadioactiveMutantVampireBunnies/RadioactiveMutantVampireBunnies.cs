using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            Queue<Tuple<int, int>> bunnyMultiply = new Queue<Tuple<int, int>>();
            bunnyMultiply.Enqueue(new Tuple<int, int>(-1, 0));
            bunnyMultiply.Enqueue(new Tuple<int, int>(0, 1));
            bunnyMultiply.Enqueue(new Tuple<int, int>(1, 0));
            bunnyMultiply.Enqueue(new Tuple<int, int>(0, -1));
            int[] lairSizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] lair = new char[lairSizes[0], lairSizes[1]];
            for (int i = 0; i < lairSizes[0]; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < lairSizes[1]; j++)
                {
                    lair[i, j] = row[j];
                }
            }

            string commands = Console.ReadLine();
            int[] playerIndexes = new int[2];
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    if (lair[i, j] == 'P')
                    {
                        playerIndexes[0] = i;
                        playerIndexes[1] = j;
                    }
                }
            }

            bool isDead = false;
            bool isWon = false;
            foreach (var command in commands)
            {
                lair[playerIndexes[0], playerIndexes[1]] = '.';
                switch (command)
                {
                    case 'U':
                        playerIndexes[0]--;
                        if (playerIndexes[0] < 0)
                        {
                            playerIndexes[0]++;
                            isWon = true;
                        }
                        break;
                    case 'D':
                        playerIndexes[0]++;
                        if (playerIndexes[0] >= lair.GetLength(0))
                        {
                            playerIndexes[0]--;
                            isWon = true;
                        }
                        break;
                    case 'L':
                        playerIndexes[1]--;
                        if (playerIndexes[1] < 0)
                        {
                            playerIndexes[1]++;
                            isWon = true;
                        }
                        break;
                    case 'R':
                        playerIndexes[1]++;
                        if (playerIndexes[1] >= lair.GetLength(1))
                        {
                            playerIndexes[1]--;
                            isWon = true;
                        }
                        break;
                }

                if (lair[playerIndexes[0], playerIndexes[1]] == 'B')
                {
                    isDead = true;
                }
                else if (lair[playerIndexes[0], playerIndexes[1]] != 'B' && !isWon)
                {
                    lair[playerIndexes[0], playerIndexes[1]] = 'P';
                }

                Queue<int[]> bunniesIndexes = new Queue<int[]>();
                for (int i = 0; i < lair.GetLength(0); i++)
                {
                    for (int j = 0; j < lair.GetLength(1); j++)
                    {
                        if (lair[i, j] == 'B')
                        {
                            bunniesIndexes.Enqueue(new[] { i, j });
                        }
                    }
                }

                int bunnyCount = bunniesIndexes.Count;
                for (int i = 0; i < bunnyCount; i++)
                {
                    int bunnyIdxRow = bunniesIndexes.Peek()[0];
                    int bunnyIdxCol = bunniesIndexes.Peek()[1];
                    bunniesIndexes.Dequeue();
                    for (int k = 0; k < bunnyMultiply.Count; k++)
                    {
                        int mplyIdxRow = bunnyMultiply.Peek().Item1;
                        int mplyIdxCol = bunnyMultiply.Peek().Item2;
                        bunnyMultiply.Enqueue(bunnyMultiply.Dequeue());
                        try
                        {
                            if (lair[bunnyIdxRow + mplyIdxRow, bunnyIdxCol + mplyIdxCol] == 'P')
                            {
                                isDead = true;
                                lair[playerIndexes[0], playerIndexes[1]] = '.';
                            }
                            lair[bunnyIdxRow + mplyIdxRow, bunnyIdxCol + mplyIdxCol] = 'B';
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
                if (isWon || isDead)
                {
                    break;
                }
            }
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    Console.Write(lair[i, j]);
                }

                Console.WriteLine();
            }
            Console.WriteLine(isWon ? $"won: {playerIndexes[0]} {playerIndexes[1]}" : $"dead: {playerIndexes[0]} {playerIndexes[1]}");
        }
    }
}