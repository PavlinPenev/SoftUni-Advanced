using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string studentName = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);
                if (!studentGrades.ContainsKey(studentName))
                {
                    studentGrades.Add(studentName, new List<decimal>());
                }
                studentGrades[studentName].Add(grade);
            }

            foreach (var student in studentGrades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(v => $"{v:f2}"))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
