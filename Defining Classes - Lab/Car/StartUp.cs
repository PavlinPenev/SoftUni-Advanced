using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        //These are all the problems in the contest combined since it requires you to build it up step by step. Just watch the requirements and you can build it by yourself.
        static void Main(string[] args)
        {
            string input;
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            while ((input = Console.ReadLine()) != "No more tires")
            {
                List<string> tireSet = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                Tire[] currentTireSet = new Tire[4];
                for (int i = 0; i < 4; i++)
                {
                    Tire currentTire = new Tire(int.Parse(tireSet[0]), double.Parse(tireSet[1]));
                    currentTireSet[i] = currentTire;
                    tireSet.RemoveAt(0);
                    tireSet.RemoveAt(0);
                }
                tires.Add(currentTireSet);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine currentEngine = new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1]));
                engines.Add(currentEngine);
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = engines[int.Parse(carInfo[5])];
                Tire[] tireSet = tires[int.Parse(carInfo[6])];
                Car currentCar = new Car(carInfo[0], carInfo[1], int.Parse(carInfo[2]), double.Parse(carInfo[3]), double.Parse(carInfo[4]), engine, tireSet);
                cars.Add(currentCar);
            }

            cars = cars.Where(c =>
                c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 &&
                c.Tires.Sum(t => t.Pressure) <= 10).ToList();
            
            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
