using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racerToRemove = data.FirstOrDefault(r => r.Name == name);
            if (racerToRemove == null)
            {
                return false;
            }

            data.Remove(racerToRemove);
            return true;
        }

        public Racer GetOldestRacer()
            => data.OrderByDescending(r => r.Age).FirstOrDefault();

        public Racer GetRacer(string name)
            => data.FirstOrDefault(r => r.Name == name);

        public Racer GetFastestRacer()
            => data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
