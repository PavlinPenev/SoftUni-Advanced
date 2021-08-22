using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> ocurrances = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();
                if (!ocurrances.ContainsKey(value))
                {
                    ocurrances.Add(value, 0);
                }

                ocurrances[value]++;
            }

            Console.WriteLine(ocurrances.First(o => o.Value % 2 == 0).Key);
        }
    }
}
