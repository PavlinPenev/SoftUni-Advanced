using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            List<Engine> engineModels = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine currentEngine = new Engine(engineInfo[0], engineInfo[1]);
                try
                {
                    if (Int32.TryParse(engineInfo[2], out _))
                    {
                        currentEngine.Displacement = engineInfo[2];
                    }
                    else
                    {
                        currentEngine.Efficiency = engineInfo[2];
                    }
                    if (Int32.TryParse(engineInfo[3], out _))
                    {
                        currentEngine.Displacement = engineInfo[3];
                    }
                    else
                    {
                        currentEngine.Efficiency = engineInfo[3];
                    }

                }
                catch (Exception)
                { 
                }
                engineModels.Add(currentEngine);
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car currentCar = new Car(carInfo[0], engineModels.First(e => e.Model == carInfo[1]));
                try
                {
                    if (Int32.TryParse(carInfo[2], out _))
                    {
                        currentCar.Weight = carInfo[2];
                    }
                    else
                    {
                        currentCar.Color = carInfo[2];
                    }
                    if (Int32.TryParse(carInfo[3], out _))
                    {
                        currentCar.Weight = carInfo[3];
                    }
                    else
                    {
                        currentCar.Color = carInfo[3];
                    }
                }
                catch (Exception)
                {
                }
                cars.Add(currentCar);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
