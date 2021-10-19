using System;

namespace TheRace
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize the repository
            Race race = new Race("Indianapolis 500", 10);

            //Initialzie cars
            Car car1 = new Car("ferrari", 150);
            Car car2 = new Car("lambo", 170);

            //Initialize racer1
            Racer racer1 = new Racer("Stephen", 40, "Bulgaria", car1);

            //Print Racer
            Console.WriteLine(racer1); //Racer: Stephen, 40 (Bulgaria)

            //Add Racer
            race.Add(racer1);
            //Remove Racer
            race.Remove("Vin Benzin"); //false

            Racer racer2 = new Racer("Mark", 34, "UK", car2);

            //Add Racer
            race.Add(racer2);

            Racer oldestRacer = race.GetOldestRacer(); // Racer with name Stephen
            Racer racerStephen = race.GetRacer("Stephen"); // Racer with name Stephen
            Racer fastestRacer = race.GetFastestRacer(); // Racer with name Mark

            Console.WriteLine(oldestRacer); //Racer: Stephen, 40 (Bulgaria)
            Console.WriteLine(racerStephen); //Racer: Stephen, 40 (Bulgaria)
            Console.WriteLine(fastestRacer); // Racer: Mark, 34 (UK)
            Console.WriteLine(race.Count); //2

            Console.WriteLine(race.Report());
            //Racers working at Indianapolis 500:
            //Racer: Stephen, 40 (Bulgaria)
            //Racer: Mark, 34 (UK)

        }
    }
}
