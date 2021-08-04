using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRackClothes = 0;
            int rackCounter = 1;

            while (clothes.Count > 0)
            {
                if(currentRackClothes + clothes.Peek() > rackCapacity)
                {
                    currentRackClothes = 0;
                    rackCounter++;
                }
                currentRackClothes += clothes.Pop();
            }

            Console.WriteLine(rackCounter);
        }
    }
}
