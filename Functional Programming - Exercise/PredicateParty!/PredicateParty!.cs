using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty_
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> partyPeople = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Predicate<string> command = GetPredicate(commands[1], commands[2]);
                switch (commands[0])
                {
                    case "Double":
                        List<string> doubleIt = partyPeople.FindAll(command);
                        if (doubleIt.Any())
                        {
                            int idx = partyPeople.FindIndex(command);
                            partyPeople.InsertRange(idx, doubleIt);
                        }
                        break;
                    case "Remove":
                        partyPeople.RemoveAll(command);
                        break;
                }
            }

            Console.WriteLine(partyPeople.Any() ? $"{string.Join(", ", partyPeople)} are going to the party!" : "Nobody is going to the party!");
        }
        private static Predicate<string> GetPredicate(string commandType, string arg)
        {
            switch (commandType)
            {
                case "StartsWith":
                    return (name) => name.StartsWith(arg);
                case "EndsWith":
                    return (name) => name.EndsWith(arg);
                case "Length":
                    return (name) => name.Length == int.Parse(arg);
                default:
                    throw new ArgumentException("Invalid command type: " + commandType);
            }
        }
    }
}
