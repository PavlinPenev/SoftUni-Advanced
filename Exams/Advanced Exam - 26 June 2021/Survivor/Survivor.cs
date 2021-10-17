using System;
using System.Linq;

namespace Survivor
{
    class Survivor
    {
        static void Main(string[] args)
        {
            int beachRows = int.Parse(Console.ReadLine());
            string[][] beach = new string[beachRows][];
            for (int i = 0; i < beachRows; i++)
            {
                beach[i] = Console.ReadLine().Split();
            }

            int collectedTokens = 0;
            int opponentCollectedTokens = 0;
            string input;
            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (commandArgs[0])
                {
                    case "Find":
                        int findRowIdx = int.Parse(commandArgs[1]);
                        int findColIdx = int.Parse(commandArgs[2]);
                        if (ValidationIndexes(findRowIdx, findColIdx, beach))
                        {
                            if (beach[findRowIdx][findColIdx] == "T")
                            {
                                collectedTokens++;
                            }
                            beach[findRowIdx][findColIdx] = "-";
                        }

                        break;
                    case "Opponent":
                        int opponentRowIdx = int.Parse(commandArgs[1]);
                        int opponentColIdx = int.Parse(commandArgs[2]);
                        string direction = commandArgs[3];
                        if (ValidationIndexes(opponentRowIdx, opponentColIdx, beach))
                        {
                            if (beach[opponentRowIdx][opponentColIdx] == "T")
                            {
                                opponentCollectedTokens++;
                            }

                            beach[opponentRowIdx][opponentColIdx] = "-";
                            for (int i = 0; i < 3; i++)
                            {
                                switch (direction)
                                {
                                    case "up":
                                        opponentRowIdx--;
                                        break;
                                    case "down":
                                        opponentRowIdx++;
                                        break;
                                    case "left":
                                        opponentColIdx--;
                                        break;
                                    case "right":
                                        opponentColIdx++;
                                        break;
                                }

                                if (ValidationIndexes(opponentRowIdx,opponentColIdx, beach))
                                {
                                    if (beach[opponentRowIdx][opponentColIdx] == "T")
                                    {
                                        opponentCollectedTokens++;
                                        beach[opponentRowIdx][opponentColIdx] = "-";
                                    }
                                }
                            }
                        }

                        break;
                }
            }

            for (int i = 0; i < beach.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(" ", beach[i]));
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentCollectedTokens}");
        }

        private static bool ValidationIndexes(int findRowIdx, int findColIdx, string[][] beach)
        {
            return (findRowIdx >= 0 && findRowIdx < beach.GetLength(0)) &&
                   (findColIdx >= 0 && findColIdx < beach[findRowIdx].Length);
        }
    }
}
