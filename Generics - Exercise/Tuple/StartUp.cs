using System;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split();
            string name = $"{first[0]} {first[1]}";
            string address = first[2];
            Tuple<string, string> firstTuple = new Tuple<string, string>(name, address);
            Console.WriteLine(firstTuple);
            string[] second = Console.ReadLine().Split();
            Tuple<string, int> secondTuple = new Tuple<string, int>(second[0], int.Parse(second[1]));
            Console.WriteLine(secondTuple);
            string[] third = Console.ReadLine().Split();
            Tuple<int, double> numbers = new Tuple<int, double>(int.Parse(third[0]), double.Parse(third[1]));
            Console.WriteLine(numbers);
        }
    }
}
