namespace GenericCountMethodDouble
{
    public class Box<T>
    {
        public Box(T value)
        {
            Value = value;
        }

        public T Value { get; set; }



        public override string ToString()
            => $"{typeof(T)}: {Value}";
    }
}
