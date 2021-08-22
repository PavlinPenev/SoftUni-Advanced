using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> theVLogger = new Dictionary<string, Vlogger>();
            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] splt = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string username = splt[0];
                string username2 = splt[2];
                switch (splt[1])
                {
                    case "joined":
                        if (!theVLogger.ContainsKey(username))
                        {
                            theVLogger.Add(username, new Vlogger());
                        }
                        break;
                    case "followed":
                        if (theVLogger.ContainsKey(username) && theVLogger.ContainsKey(username2) && username2 != username)
                        {
                            theVLogger[username].Following.Add(username2);
                            theVLogger[username2].Followers.Add(username);
                        }
                        break;
                }
            }

            theVLogger = theVLogger.OrderByDescending(v => v.Value.Followers.Count).ThenBy(v => v.Value.Following.Count)
                .ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine($"The V-Logger has a total of {theVLogger.Count} vloggers in its logs.");
            Console.WriteLine($"1. {theVLogger.First().Key} : {theVLogger.First().Value.Followers.Count} followers, {theVLogger.First().Value.Following.Count} following");
            foreach (var follower in theVLogger.First().Value.Followers.OrderBy(f => f))
            {
                Console.WriteLine($"*  {follower}");
            }

            theVLogger.Remove(theVLogger.First().Key);
            int counter = 2;
            foreach (var vlogger in theVLogger.OrderByDescending(f => f.Value.Followers.Count).ThenBy(f => f.Value.Following.Count))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
                counter++;
            }
        }
    }

    class Vlogger
    {
        public Vlogger()
        {
            Followers = new HashSet<string>();
            Following = new HashSet<string>();
        }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
    }
}
