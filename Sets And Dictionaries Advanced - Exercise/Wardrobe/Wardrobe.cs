using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Clothes> clothes = new List<Clothes>();
            for (int i = 0; i < n; i++)
            {
                string[] firstSplit = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = firstSplit[0];
                string[] secondSplit = firstSplit[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                Clothes currentClothing = new Clothes(color, new List<Type>());
                foreach (var s in secondSplit)
                {
                    Type typeOfClothing = new Type(s);
                    if (!clothes.Any(c => c.Color == currentClothing.Color))
                    {
                        clothes.Add(currentClothing);
                    }

                    int idx = clothes.FindIndex(c => c.Color == color);
                    if (!clothes[idx].Type.Any(t => t.ClothesType == s))
                    {
                        clothes[idx].Type.Add(typeOfClothing);
                    }
                    int countIdx = clothes[idx].Type.FindIndex(t => t.ClothesType == s);
                    clothes[idx].Type[countIdx].Count++;
                }  
            }
            string[] lookingFor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colour = lookingFor[0];
            string clothing = lookingFor[1];
            foreach (var cloth in clothes)
            {
                Console.WriteLine($"{cloth.Color} clothes:");
                foreach (var type in cloth.Type)
                {
                    Console.WriteLine(type.ToStrings(clothing, colour, cloth.Color));
                }
            }
        }
    }

    class Clothes
    {
        public Clothes(string color, List<Type> type)
        {
            Color = color;
            Type = type;
        }
        public string Color { get; set; }
        public List<Type> Type { get; set; }
    }

    class Type
    {
        public Type(string type)
        {
            ClothesType = type;
        }
        public string ClothesType { get; set; }
        public int Count { get; set; }
        public string ToStrings(string type, string color, string color2)
        {
            return type == ClothesType && color == color2 ? $"* {ClothesType} - {Count} (found!)" : $"* {ClothesType} - {Count}";
        }
    }
}
