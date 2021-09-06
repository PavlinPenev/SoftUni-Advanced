using System;
using GenericBoxOfString;

namespace GenericBoxOfIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Box<int> integer = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(integer);
            }
        }
    }
}
