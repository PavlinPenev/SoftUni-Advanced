using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> partyPeople = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string,Predicate<string>> filters = new Dictionary<string, Predicate<string>>();
            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] addRemFilter = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string addRemove = addRemFilter[0];
                string condition = addRemFilter[1];
                string argument = addRemFilter[2];
                switch (addRemove)
                {
                    case "Add filter":
                        Predicate<string> currentPredicate = GetPredicate(condition, argument);
                        filters.Add(argument, currentPredicate);
                        break;
                    case "Remove filter":
                        currentPredicate = GetPredicate(condition, argument);
                        filters.Remove(argument);
                        break;
                }
            }
            
            foreach (var filter in filters)
            {
                partyPeople.RemoveAll(filter.Value);
            }
            Console.WriteLine(string.Join(" ", partyPeople));
        }
        private static Predicate<string> GetPredicate(string commandType, string arg)
        {
            switch (commandType)
            {
                case "Starts with":
                    return (name) => name.StartsWith(arg);
                case "Ends with":
                    return (name) => name.EndsWith(arg);
                case "Length":
                    return (name) => name.Length == int.Parse(arg);
                case "Contains":
                    return (name) => name.Contains(arg);
                default:
                    throw new ArgumentException("Invalid command type: " + commandType);
            }
        }
    }
}
