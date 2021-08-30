using System;

namespace Cars
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TravelledDistance { get; set; } = 0;

        public void Drive(double distance)
        {
            double fuelConsumed = distance * FuelConsumptionPerKm;
            if (FuelAmount - fuelConsumed >= 0)
            {
                FuelAmount -= fuelConsumed;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
