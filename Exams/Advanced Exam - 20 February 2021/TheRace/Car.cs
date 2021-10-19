namespace TheRace
{
    public class Car
    {
        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        public string Name { get; set; }
        public int Speed { get; set; }
    }
}
