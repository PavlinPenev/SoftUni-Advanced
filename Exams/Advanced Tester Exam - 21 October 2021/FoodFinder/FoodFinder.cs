using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodFinder
{
    class FoodFinder
    {
        static void Main(string[] args)
        {
            const string food1 = "pear";
            const string food2 = "flour";
            const string food3 = "pork";
            const string food4 = "olive";
            Dictionary<string, FoodBuilder> dict = new Dictionary<string, FoodBuilder>();
            dict[food1] = new FoodBuilder();
            dict[food2] = new FoodBuilder();
            dict[food3] = new FoodBuilder();
            dict[food4] = new FoodBuilder();
            Queue<char> vowels =
                new Queue<char>(string.Concat(Console.ReadLine().Where(c => !char.IsWhiteSpace(c))).ToCharArray());
            Stack<char> consonants =
                new Stack<char>(string.Concat(Console.ReadLine().Where(c => !char.IsWhiteSpace(c))).ToCharArray());
            int wordsFound = 0;
            while (consonants.Any())
            {
                char currentVowel = vowels.Peek();
                char currentConsonant = consonants.Pop();
                vowels.Enqueue(vowels.Dequeue());
                foreach (var food in dict)
                {
                    if (food.Key.Contains(currentVowel))
                    {
                        if (!food.Value.BuildWord.ToString().Contains(currentVowel))
                        {
                            food.Value.BuildWord.Append(currentVowel);
                        }
                    }

                    if (food.Key.Contains(currentConsonant))
                    {
                        if (!food.Value.BuildWord.ToString().Contains(currentConsonant))
                        {
                            food.Value.BuildWord.Append(currentConsonant);
                        }
                    }

                    if (food.Value.BuildWord.Length == food.Key.Length)
                    {
                        food.Value.WordCount++;
                        food.Value.BuildWord.Clear();
                    }
                }
            }

            wordsFound = dict.Values.Sum(f => f.WordCount);
            Console.WriteLine($"Words found: {wordsFound}");
            foreach (var food in dict.Where(v => v.Value.WordCount > 0))
            {
                Console.WriteLine(food.Key);
            }
        }
    }

    class FoodBuilder
    {
        public FoodBuilder()
        {
            BuildWord = new StringBuilder();
        }
        public StringBuilder BuildWord { get; set; }
        public int WordCount { get; set; }

    }
}
