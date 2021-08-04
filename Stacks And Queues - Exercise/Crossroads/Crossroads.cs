using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindowTime = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int counter = 0;
            while (command != "END")
            {
                int greenLightLeft = greenLight;
                int freeWindowLeft = freeWindowTime;
                switch (command)
                {
                    case "green":
                        while (greenLightLeft > 0 && cars.Any())
                        {
                            string car = cars.Dequeue();
                            greenLightLeft -= car.Length;
                            if (greenLightLeft >= 0)
                            {
                                counter++;
                            }
                            else
                            {
                                freeWindowLeft += greenLightLeft;
                                if (freeWindowLeft < 0)
                                {
                                    Console.WriteLine($"A crash happened!{Environment.NewLine}{car} was hit at {car[car.Length + freeWindowLeft]}.");
                                    return;
                                }

                                counter++;
                            }
                        }
                        break;
                    default:
                        cars.Enqueue(command);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine( $"Everyone is safe.{Environment.NewLine}{counter} total cars passed the crossroads.");
        }
    }
}
