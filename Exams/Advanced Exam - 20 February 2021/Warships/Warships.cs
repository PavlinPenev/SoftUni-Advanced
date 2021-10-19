using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Warships
{
    class Warships
    {
        static void Main(string[] args)
        {
            Queue<Tuple<int, int>> mineAOE = new Queue<Tuple<int, int>>();
            mineAOE.Enqueue(new Tuple<int, int>(-1, -1));
            mineAOE.Enqueue(new Tuple<int, int>(-1, 0));
            mineAOE.Enqueue(new Tuple<int, int>(-1, 1));
            mineAOE.Enqueue(new Tuple<int, int>(0, 1));
            mineAOE.Enqueue(new Tuple<int, int>(1, 1));
            mineAOE.Enqueue(new Tuple<int, int>(1, 0));
            mineAOE.Enqueue(new Tuple<int, int>(1, -1));
            mineAOE.Enqueue(new Tuple<int, int>(0, -1));

            int fieldSize = int.Parse(Console.ReadLine());
            char[,] field = new char[fieldSize, fieldSize];
            string[] attackCoordinates = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            char firstPlayerShip = '<';
            char secondPlayerShip = '>';
            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] fieldInfo = string.Concat(Console.ReadLine().Where(c => !char.IsWhiteSpace(c))).ToCharArray();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = fieldInfo[j];
                }
            }

            int player1Ships = CountShips(field, firstPlayerShip);
            int player2Ships = CountShips(field, secondPlayerShip);
            int sunkShipsCounter = 0;

            foreach (var attack in attackCoordinates)
            {
                int[] coordinates = attack.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (ValidatePosition(field, coordinates[0], coordinates[1]))
                {
                    switch (field[coordinates[0], coordinates[1]])
                    {
                        case '<':
                            field[coordinates[0], coordinates[1]] = 'X';
                            player1Ships--;
                            sunkShipsCounter++;
                            break;
                        case '>':
                            field[coordinates[0], coordinates[1]] = 'X';
                            player2Ships--;
                            sunkShipsCounter++;
                            break;
                        case '#':
                            for (int i = 0; i < mineAOE.Count; i++)
                            {
                                field[coordinates[0], coordinates[1]] = 'X';
                                int offsetRow = mineAOE.Peek().Item1;
                                int offsetCol = mineAOE.Peek().Item2;
                                mineAOE.Enqueue(mineAOE.Dequeue());
                                if (ValidatePosition(field, coordinates[0] + offsetRow, coordinates[1] + offsetCol))
                                {
                                    if (field[coordinates[0] + offsetRow, coordinates[1] + offsetCol] == firstPlayerShip)
                                    {
                                        player1Ships--;
                                        sunkShipsCounter++;
                                        field[coordinates[0] + offsetRow, coordinates[1] + offsetCol] = 'X';
                                    }
                                    else if (field[coordinates[0] + offsetRow, coordinates[1] + offsetCol] == secondPlayerShip)
                                    {
                                        player2Ships--;
                                        sunkShipsCounter++;
                                        field[coordinates[0] + offsetRow, coordinates[1] + offsetCol] = 'X';
                                    }
                                }
                            }
                            break;
                    }
                }

                if (player1Ships <= 0 || player2Ships <= 0)
                {
                    break;
                }
            }

            if (player1Ships <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {sunkShipsCounter} ships have been sunk in the battle.");
            }
            else if (player2Ships <= 0)
            {
                Console.WriteLine(
                    $"Player One has won the game! {sunkShipsCounter} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {player1Ships} ships left. Player Two has {player2Ships} ships left.");
            }
        }

        private static int CountShips(char[,] field, char shipSymbol)
        {
            return (from char element in field where element == shipSymbol select element).Count();
        }
        private static bool ValidatePosition(char[,] field, int attackPositionRow, int attackPositionCol)
        {
            return (attackPositionRow >= 0 && attackPositionRow < field.GetLength(0)) && (attackPositionCol >= 0 && attackPositionCol < field.GetLength(1));
        }
    }
}
