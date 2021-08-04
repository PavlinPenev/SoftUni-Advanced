using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int numPumps = int.Parse(Console.ReadLine());
            Queue<Pump> pumps = new Queue<Pump>();
            long petrolAmount = 0;
            for (int i = 0; i < numPumps; i++)
            {
                long[] amountDistance = Console.ReadLine().Split().Select(long.Parse).ToArray();
                Pump currentPump = new Pump(i, amountDistance[0], amountDistance[1]);
                pumps.Enqueue(currentPump);
            }

            bool isEnough = false;
            int counter = 0;
            while (!isEnough)
            {
                petrolAmount += pumps.Peek().PetrolAmount;
                if (petrolAmount >= pumps.Peek().DistanceToNext)
                {
                    counter++;
                    petrolAmount -= pumps.Peek().DistanceToNext;
                }
                else
                {
                    petrolAmount = 0;
                    counter = 0;
                }
                pumps.Enqueue(pumps.Dequeue());
                if (counter == numPumps)
                {
                    isEnough = true;
                }
            }

            Console.WriteLine(pumps.Peek().Name);
        }
    }

    class Pump
    {
        public Pump(int name, long amount, long distance)
        {
            Name = name;
            PetrolAmount = amount;
            DistanceToNext = distance;
        }
        public long PetrolAmount { get; set; }
        public long DistanceToNext { get; set; }
        public int Name { get; set; }    
    }
}
