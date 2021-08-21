using System;
using System.Collections.Generic;

namespace KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            Queue<Tuple<int, int>> knightPossibleMoves = new Queue<Tuple<int, int>>();
            knightPossibleMoves.Enqueue(new Tuple<int, int>(-1, -2));
            knightPossibleMoves.Enqueue(new Tuple<int, int>(1, -2));
            knightPossibleMoves.Enqueue(new Tuple<int, int>(-2, -1));
            knightPossibleMoves.Enqueue(new Tuple<int, int>(2, -1));
            knightPossibleMoves.Enqueue(new Tuple<int, int>(-2, 1));
            knightPossibleMoves.Enqueue(new Tuple<int, int>(2, 1));
            knightPossibleMoves.Enqueue(new Tuple<int, int>(-1, 2));
            knightPossibleMoves.Enqueue(new Tuple<int, int>(1, 2));
            int chessBoardSize = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[chessBoardSize, chessBoardSize];
            for (int i = 0; i < chessBoardSize; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < chessBoardSize; j++)
                {
                    chessBoard[i, j] = row[j];
                }
            }

            bool foundMost = true;
            int currentKnightsAround = 0;
            int mostKnightsAround = 0;
            int IdxRowMostKnights = int.MinValue;
            int IdxColMostKnights = int.MinValue;
            int counter = 0;
            while (foundMost)
            {
                for (int i = 0; i < chessBoardSize; i++)
                {
                    for (int j = 0; j < chessBoardSize; j++)
                    {
                        if (chessBoard[i, j] == 'K')
                        {
                            for (int k = 1; k <= knightPossibleMoves.Count; k++)
                            {
                                int row = knightPossibleMoves.Peek().Item1;
                                int col = knightPossibleMoves.Peek().Item2;
                                knightPossibleMoves.Enqueue(knightPossibleMoves.Dequeue());
                                try
                                {
                                    if (chessBoard[i + row, j + col] == 'K')
                                    {
                                        currentKnightsAround++;
                                    }
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }
                        }

                        foundMost = currentKnightsAround > 0 ? true : false;
                        if (currentKnightsAround > mostKnightsAround)
                        {
                            IdxRowMostKnights = i;
                            IdxColMostKnights = j;
                            mostKnightsAround = currentKnightsAround;
                        }

                        currentKnightsAround = 0;
                    }
                }
                if (foundMost = true && IdxRowMostKnights != int.MinValue && IdxColMostKnights != int.MinValue)
                {
                    chessBoard[IdxRowMostKnights, IdxColMostKnights] = '0';
                    counter++;
                }

                mostKnightsAround = 0;
                IdxRowMostKnights = int.MinValue;
                IdxColMostKnights = int.MinValue;
            }

            Console.WriteLine(counter);
        }
    }
}
