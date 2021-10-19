namespace TheRace
{
    public class Racer
    {
        public Racer(string name, int age, string country, Car car)
        {
            Name = name;
            Age = age;
            Country = country;
            Car = car;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public Car Car { get; set; }

        public override string ToString()
            => $"Racer: {Name}, {Age} ({Country})";
    }
}
