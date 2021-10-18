using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class TheFightForGondor
    {
        static void Main(string[] args)
        {
            int numOfOrcWaves = int.Parse(Console.ReadLine());
            int plateCreationCounter = 0; // on every third iteration u add a new plate to the stack
            bool platesDestroyed = false;
            Stack<int> orcWave = null;
            Queue<int> platesOfDefense = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            for (int i = 0; i < numOfOrcWaves; i++)
            {
                plateCreationCounter++;
                if (platesDestroyed)
                {
                    break;
                }
                orcWave = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
                if (plateCreationCounter == 3)
                {
                    plateCreationCounter = 0;
                    platesOfDefense.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (orcWave.Count > 0 && platesOfDefense.Count > 0)
                {
                    if (orcWave.Peek() > platesOfDefense.Peek())
                    {
                        orcWave.Push(orcWave.Pop() - platesOfDefense.Dequeue());
                    }
                    else if (platesOfDefense.Peek() > orcWave.Peek())
                    {
                        Queue<int> tempQueue = new Queue<int>();
                        tempQueue.Enqueue(platesOfDefense.Dequeue() - orcWave.Pop());
                        for (int j = 0; j < platesOfDefense.Count; j++)
                        {
                            tempQueue.Enqueue(platesOfDefense.ElementAt(j));
                        }

                        platesOfDefense = tempQueue;
                    }
                    else if (platesOfDefense.Peek() == orcWave.Peek())
                    {
                        orcWave.Pop();
                        platesOfDefense.Dequeue();
                    }

                    if (platesOfDefense.Count == 0)
                    {
                        platesDestroyed = true;
                    }
                }
            }

            Console.WriteLine(platesDestroyed ? $"The orcs successfully destroyed the Gondor's defense." : $"The people successfully repulsed the orc's attack.");
            Console.WriteLine(platesOfDefense.Any() ? $"Plates left: {string.Join(", ", platesOfDefense)}" : $"Orcs left: {string.Join(", ", orcWave)}");
        }
    }
}
