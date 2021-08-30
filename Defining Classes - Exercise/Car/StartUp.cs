using System;
using System.Collections.Generic;
using System.Linq;

namespace Cars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            string input;
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car currentCar = new Car(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]));
                cars.Add(currentCar);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] drive = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                cars.First(c => c.Model == drive[1]).Drive(double.Parse(drive[2]));
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
