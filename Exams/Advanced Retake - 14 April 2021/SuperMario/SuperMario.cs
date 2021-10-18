using System;

namespace SuperMario
{
    class SuperMario
    {
        static void Main(string[] args)
        {
            int marioHP = int.Parse(Console.ReadLine());
            int fieldRows = int.Parse(Console.ReadLine());
            char[] populateRows = Console.ReadLine().ToCharArray();
            char[,] playingField = new char[fieldRows, populateRows.Length];
            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < populateRows.Length; j++)
                {
                    playingField[i,j] = populateRows[j];
                }

                if (i == playingField.GetLength(0) - 1)
                {
                    break;
                }
                populateRows = Console.ReadLine().ToCharArray();
            }
            Mario mario = new Mario(marioHP, playingField);
            while (!mario.DeadOrPSaved)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                char move = char.Parse(command[0]);
                int indexRow = int.Parse(command[1]);
                int indexCol = int.Parse(command[2]);
                SpawnBowser(playingField, indexRow, indexCol);
                switch (move)
                {
                    case 'W':
                        mario.MoveMarioUp(playingField);
                        break;
                    case 'S':
                        mario.MoveMarioDown(playingField);
                        break;
                    case 'A':
                        mario.MoveMarioLeft(playingField);
                        break;
                    case 'D':
                        mario.MoveMarioRight(playingField);
                        break;
                }
            }

            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int j = 0; j < playingField.GetLength(1); j++)
                {
                    Console.Write(playingField[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void SpawnBowser(char[,] playingField, int indexRow, int indexCol)
        {
            playingField[indexRow,indexCol] = 'B';
        }
    }

    class Mario
    {
        public Mario(int hp, char[,] playingField)
        {
            int[] indeces = new int[2];
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    if (playingField[row,col] == 'M')
                    {
                        indeces[0] = row;
                        indeces[1] = col;
                    }
                }
            }

            HP = hp;
            IndexRow = indeces[0];
            IndexCol = indeces[1];
            DeadOrPSaved = false;
        }

        public bool DeadOrPSaved { get; set; }
        public int HP { get; set; }
        public int IndexRow { get; set; }
        public int IndexCol { get; set; }

        public void MoveMarioUp(char[,] playingField)
        {
            HP--;
            if (IndexRow - 1 >= 0 && IndexRow - 1 < playingField.GetLength(0))
            {
                if (playingField[IndexRow - 1,IndexCol] == 'B' || HP <= 0)
                {
                    if (playingField[IndexRow - 1, IndexCol] == 'B')
                    {
                        HP -= 2;
                    }
                    if (HP <= 0)
                    {
                        DeadOrPSaved = true;
                        playingField[IndexRow - 1,IndexCol] = 'X';
                        Console.WriteLine($"Mario died at {IndexRow - 1};{IndexCol}.");
                        playingField[IndexRow,IndexCol] = '-';
                        return;
                    }
                }
                else if (playingField[IndexRow - 1,IndexCol] == 'P')
                {
                    playingField[IndexRow - 1,IndexCol] = '-';
                    playingField[IndexRow,IndexCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {HP}");
                    DeadOrPSaved = true;
                    return;
                }

                playingField[IndexRow - 1,IndexCol] = 'M';
                playingField[IndexRow,IndexCol] = '-';
                IndexRow--;
                
            }
        }

        public void MoveMarioDown(char[,] playingField)
        {
            HP--;
            if (IndexRow + 1 >= 0 && IndexRow + 1 < playingField.GetLength(0))
            {
                if (playingField[IndexRow + 1,IndexCol] == 'B' || HP <= 0)
                {
                    if (playingField[IndexRow + 1, IndexCol] == 'B')
                    {
                        HP -= 2;
                    }
                    if (HP <= 0)
                    {
                        DeadOrPSaved = true;
                        playingField[IndexRow + 1,IndexCol] = 'X';
                        playingField[IndexRow,IndexCol] = '-';
                        Console.WriteLine($"Mario died at {IndexRow + 1};{IndexCol}.");
                        return;
                    }
                }
                else if (playingField[IndexRow + 1,IndexCol] == 'P')
                {
                    playingField[IndexRow + 1,IndexCol] = '-';
                    playingField[IndexRow,IndexCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {HP}");
                    DeadOrPSaved = true;
                    return;
                }
                playingField[IndexRow + 1,IndexCol] = 'M';
                playingField[IndexRow,IndexCol] = '-';
                IndexRow++;
            }
        }

        public void MoveMarioLeft(char[,] playingField)
        {
            HP--;
            if (IndexCol - 1 >= 0 && IndexCol - 1 < playingField.GetLength(1))
            {
                if (playingField[IndexRow,IndexCol - 1] == 'B' || HP <= 0)
                {
                    if (playingField[IndexRow, IndexCol - 1] == 'B')
                    {
                        HP -= 2;
                    }
                    if (HP <= 0)
                    {
                        DeadOrPSaved = true;
                        playingField[IndexRow,IndexCol - 1] = 'X';
                        playingField[IndexRow,IndexCol] = '-';
                        Console.WriteLine($"Mario died at {IndexRow};{IndexCol - 1}.");
                        return;
                    }
                }
                else if (playingField[IndexRow,IndexCol - 1] == 'P')
                {
                    playingField[IndexRow,IndexCol - 1] = '-';
                    playingField[IndexRow,IndexCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {HP}");
                    DeadOrPSaved = true;
                    return;
                }
                playingField[IndexRow,IndexCol - 1] = 'M';
                playingField[IndexRow,IndexCol] = '-';
                IndexCol--;
            }
        }

        public void MoveMarioRight(char[,] playingField)
        {
            HP--;
            if (IndexCol + 1 >= 0 && IndexCol + 1 < playingField.GetLength(1))
            {
                if (playingField[IndexRow,IndexCol + 1] == 'B' || HP <= 0)
                {
                    if (playingField[IndexRow, IndexCol + 1] == 'B')
                    {
                        HP -= 2;
                    }
                    if (HP <= 0)
                    {
                        DeadOrPSaved = true;
                        playingField[IndexRow,IndexCol + 1] = 'X';
                        playingField[IndexRow,IndexCol] = '-';
                        Console.WriteLine($"Mario died at {IndexRow};{IndexCol + 1}.");
                        return;
                    }
                }
                else if (playingField[IndexRow,IndexCol + 1] == 'P')
                {
                    playingField[IndexRow,IndexCol + 1] = '-';
                    playingField[IndexRow,IndexCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {HP}");
                    DeadOrPSaved = true;
                    return;
                }
                playingField[IndexRow,IndexCol + 1] = 'M';
                playingField[IndexRow,IndexCol] = '-';
                IndexCol++;
            }
        }
    }
}