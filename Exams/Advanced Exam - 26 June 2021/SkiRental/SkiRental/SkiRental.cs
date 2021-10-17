using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Ski ski)
        {
            if (data.Count + 1 <= Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
            if (skiToRemove == null)
            {
                return false;
            }

            data.Remove(skiToRemove);
            return true;
        }

        public Ski GetNewestSki()
            => data.OrderByDescending(s => s.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model)
            => data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString();
        }
    }
}
