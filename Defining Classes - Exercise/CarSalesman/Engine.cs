namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, string power)
        {
            Model = model;
            Power = power;
        }
        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; } = "n/a";
        public string Efficiency { get; set; } = "n/a";
        public override string ToString()
        {
            return $"{Model}:\n    Power: {Power}\n    Displacement: {Displacement}\n    Efficiency: {Efficiency}";
        }
    }
}
