using System;

namespace BattleOfTheFiveArmies
{
    class BattleOfTheFiveArmies
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();
            }
            int[] armyPosition = FindArmyPosition(field);

            bool throneReached = false;

            while (armor > 0 && !throneReached)
            {
                string[] moveSpawnCommands = Console.ReadLine().Split();
                string moveCommand = moveSpawnCommands[0];
                int spawnRowIdx = int.Parse(moveSpawnCommands[1]);
                int spawnColIdx = int.Parse(moveSpawnCommands[2]);
                field[spawnRowIdx][spawnColIdx] = 'O';
                field[armyPosition[0]][armyPosition[1]] = '-';
                switch (moveCommand)
                {
                    case "up":
                        if (ValidatePosition(field, armyPosition[0] - 1, armyPosition[1]))
                        {
                            armyPosition[0]--;
                        }
                        break;
                    case "down":
                        if (ValidatePosition(field, armyPosition[0] + 1, armyPosition[1]))
                        {
                            armyPosition[0]++;
                        }
                        break;
                    case "left":
                        if (ValidatePosition(field, armyPosition[0], armyPosition[1] - 1))
                        {
                            armyPosition[1]--;
                        }
                        break;
                    case "right":
                        if (ValidatePosition(field, armyPosition[0], armyPosition[1] + 1))
                        {
                            armyPosition[1]++;
                        }
                        break;
                }
                armor--;
                if (field[armyPosition[0]][armyPosition[1]] == 'M')
                {
                    throneReached = true;
                    field[armyPosition[0]][armyPosition[1]] = '-';
                    break;
                }

                if (field[armyPosition[0]][armyPosition[1]] == 'O')
                {
                    armor -= 2;
                }
                if (armor <= 0)
                {
                    field[armyPosition[0]][armyPosition[1]] = 'X';
                    break;
                }
                field[armyPosition[0]][armyPosition[1]] = 'A';
            }
            Console.WriteLine(armor <= 0 ? $"The army was defeated at {armyPosition[0]};{armyPosition[1]}." : $"The army managed to free the Middle World! Armor left: {armor}");
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.WriteLine(field[i]);
            }
        }

        private static bool ValidatePosition(char[][] field, int armyPositionRow, int armyPositionCol)
        {
            return (armyPositionRow >= 0 && armyPositionRow < field.GetLength(0)) && (armyPositionCol >= 0 && armyPositionCol < field[armyPositionRow].Length);
        }

        private static int[] FindArmyPosition(char[][] field)
        {
            int[] indexes = new int[2];
            bool isFound = false;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'A')
                    {
                        indexes[0] = i;
                        indexes[1] = j;
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            return indexes;
        }
    }
}
