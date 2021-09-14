using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                int engSpeed = int.Parse(carInfo[1]);
                int engPower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);
                Cargo currentCargo = new Cargo(cargoWeight, cargoType);
                Tire tire1 = new Tire(tire1Age, tire1Pressure);
                Tire tire2 = new Tire(tire2Age, tire2Pressure);
                Tire tire3 = new Tire(tire3Age, tire3Pressure);
                Tire tire4 = new Tire(tire4Age, tire4Pressure);
                List<Tire> tires = new List<Tire>();
                tires.Add(tire1);
                tires.Add(tire2);
                tires.Add(tire3);
                tires.Add(tire4);
                Engine currentEngine = new Engine(engSpeed, engPower);
                Car currentCar = new Car(model, currentEngine, tires, currentCargo);
                cars.Add(currentCar);
            }

            string filterCargoType = Console.ReadLine();
            if (filterCargoType == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.FindAll(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))));
            }
            else if (filterCargoType == "flammable")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.FindAll(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)));
            }
        }
    }
}
