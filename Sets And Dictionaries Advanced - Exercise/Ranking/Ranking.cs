using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestData = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> studentData = new Dictionary<string, Dictionary<string, int>>();
            string[] contestPass = Console.ReadLine().Split(':');

            while (contestPass[0] != "end of contests")
            {
                string contest = contestPass[0];
                string password = contestPass[1];

                contestData.Add(contest, password);
                contestPass = Console.ReadLine().Split(':');
            }

            string[] submData = Console.ReadLine().Split("=>");

            while (submData[0] != "end of submissions")
            {
                string contest = submData[0];
                string password = submData[1];
                string student = submData[2];
                int contestPoints = int.Parse(submData[3]);

                bool valid = Validation(contest, password, contestData);
                if (valid)
                {
                    if (!studentData.ContainsKey(student))
                    {
                        studentData.Add(student, new Dictionary<string, int>());
                        studentData[student].Add(contest, contestPoints);
                    }
                    else
                    {
                        if (studentData[student].ContainsKey(contest))
                        {
                            if (studentData[student][contest] < contestPoints)
                            {
                                studentData[student][contest] = contestPoints;
                            }
                        }
                        else
                        {
                            studentData[student].Add(contest, contestPoints);
                        }
                    }
                }
                submData = Console.ReadLine().Split("=>");
            }

            string bestCand = string.Empty;
            int highestPoints = 0;
            foreach (var student in studentData)
            {
                int sum = 0;
                foreach (var contest in student.Value)
                {
                    sum += contest.Value;
                }
                if (sum > highestPoints)
                {
                    bestCand = student.Key;
                    highestPoints = sum;
                }
            }
            Console.WriteLine($"Best candidate is {bestCand} with total {highestPoints} points.");
            studentData = studentData.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
            Console.WriteLine("Ranking: ");
            foreach (var student in studentData)
            {
                Console.WriteLine(student.Key);
                foreach (var contest in student.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        static bool Validation(string con, string pass, Dictionary<string, string> dict)
        {
            if (dict.ContainsKey(con))
            {
                if (dict[con].Contains(pass))
                {
                    return true;
                }
            }

            return false;
        }
    }
}