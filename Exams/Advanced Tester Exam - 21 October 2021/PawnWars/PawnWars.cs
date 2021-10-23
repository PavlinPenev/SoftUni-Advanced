using System;

namespace PawnWars
{
    class PawnWars
    {
        static void Main(string[] args)
        {
            char[,] chessboard = new char[8, 8];
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    chessboard[i, j] = row[j];
                }
            }

            int whiteRowIdx = 0;
            int whiteColIdx = 0;
            int blackRowIdx = 0;
            int blackColIdx = 0;
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    if (chessboard[i,j] == 'w')
                    {
                        whiteRowIdx = i;
                        whiteColIdx = j;
                    }

                    if (chessboard[i,j] == 'b')
                    {
                        blackRowIdx = i;
                        blackColIdx = j;
                    }
                }
            }

            int turnCounter = 0;
            while (true)
            {
                if (turnCounter % 2 == 0)
                {
                    if (ValidatePosition(chessboard, whiteRowIdx - 1, whiteColIdx - 1))
                    {
                        if (chessboard[whiteRowIdx - 1, whiteColIdx - 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {(char)(blackColIdx + 97)}{8 - blackRowIdx}.");
                            return;
                        }
                    }
                    if (ValidatePosition(chessboard, whiteRowIdx - 1, whiteColIdx + 1))
                    {
                        if (chessboard[whiteRowIdx - 1, whiteColIdx + 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {(char)(blackColIdx + 97)}{8 - blackRowIdx}.");
                            return;
                        }
                    }

                    chessboard[whiteRowIdx, whiteColIdx] = '-';
                    whiteRowIdx--;
                    if (whiteRowIdx == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whiteColIdx + 97)}{8 - whiteRowIdx}.");
                        return;
                    }
                    chessboard[whiteRowIdx, whiteColIdx] = 'w';

                }
                else
                {
                    if (ValidatePosition(chessboard, blackRowIdx + 1, blackColIdx + 1))
                    {
                        if (chessboard[blackRowIdx + 1, blackColIdx + 1] == 'w')
                        {
                            Console.WriteLine($"Game over! Black capture on {(char)(whiteColIdx + 97)}{8 - whiteRowIdx}.");
                            return;
                        }
                    }
                    if (ValidatePosition(chessboard, blackRowIdx + 1, blackColIdx - 1))
                    {
                        if (chessboard[blackRowIdx + 1, blackColIdx - 1] == 'w')
                        {
                            Console.WriteLine($"Game over! Black capture on {(char)(whiteColIdx + 97)}{8 - whiteRowIdx}.");
                            return;
                        }
                    }
                    chessboard[blackRowIdx, blackColIdx] = '-';

                    blackRowIdx++;
                    if (blackRowIdx == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackColIdx + 97)}{8 - blackRowIdx}.");
                        return;
                    }
                    chessboard[blackRowIdx, blackColIdx] = 'b';

                }
                
                turnCounter++;
            }
        }
        private static bool ValidatePosition(char[,] field, int attackPositionRow, int attackPositionCol)
        {
            return (attackPositionRow >= 0 && attackPositionRow < field.GetLength(0)) && (attackPositionCol >= 0 && attackPositionCol < field.GetLength(1));
        }
    }
}
