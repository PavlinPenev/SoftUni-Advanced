using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIteratorTask
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            ListyIterator<string> iterator = new ListyIterator<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                List<string> commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string command = commands[0];
                switch (command)
                {
                    case "Create":
                        commands.RemoveAt(0);
                        if (commands.Count > 0)
                        {
                            iterator = new ListyIterator<string>(commands.ToArray());
                        }
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Print":
                        iterator.Print();
                        break;
                    case "PrintAll":
                        iterator.PrintAll();
                        break;
                }
            }
        }
    }
}
