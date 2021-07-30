using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string command = Console.ReadLine();
            int counter = 0;
            while (command != "end")
            {
                if (command == "green")
                {
                    int count = cars.Count;
                    for (int i = 0; i < (count < greenLight ? count : greenLight); i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }

                    command = Console.ReadLine();
                    continue;
                }
                cars.Enqueue(command);
                command = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
