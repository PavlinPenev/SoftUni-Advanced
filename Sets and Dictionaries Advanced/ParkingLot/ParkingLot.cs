using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            string reg;
            HashSet<string> licensePlates = new HashSet<string>();
            while ((reg = Console.ReadLine()) != "END")
            {
                string[] splt = reg.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                switch (splt[0])
                {
                    case "IN":
                        licensePlates.Add(splt[1]);
                        break;
                    case "OUT":
                        licensePlates.Remove(splt[1]);
                        break;
                }
            }

            Console.WriteLine(licensePlates.Any() ? string.Join(Environment.NewLine, licensePlates) : "Parking Lot is Empty");
        }
    }
}
