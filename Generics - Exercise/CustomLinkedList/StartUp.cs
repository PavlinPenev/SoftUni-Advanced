using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> myList = new DoublyLinkedList<int>();
            myList.AddFirst(3);
            myList.AddFirst(0);
            myList.AddLast(30);
            Console.WriteLine($"Count: {myList.Count}");
            myList.ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"Removed:{myList.RemoveFirst()}");
            myList.ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"Removed:{myList.RemoveLast()}");
            Console.WriteLine($"Count: {myList.Count}");

            myList.ForEach(x => Console.WriteLine(x));
        }
    }
}
