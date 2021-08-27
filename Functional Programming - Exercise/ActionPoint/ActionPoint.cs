using System;
using System.Linq;

namespace ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            Action<string> print = str => Console.WriteLine(str);
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(print);
        }
    }
}
