namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }
        public int HorsePower { get => horsePower; set { horsePower = value; } }
        public double CubicCapacity { get => cubicCapacity; set { cubicCapacity = value; } }
    }
}
