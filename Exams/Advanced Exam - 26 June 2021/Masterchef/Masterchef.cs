using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Masterchef
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshnessList = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int[]> madeDishes = new Dictionary<string, int[]>();
            int dishCounter = 0;

            while (ingredients.Count > 0 && freshnessList.Count > 0)
            {
                if (ingredients.Peek() <= 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                int potentialDish = ingredients.Peek() * freshnessList.Peek();
                string dish = string.Empty;
                if (potentialDish == 150 || potentialDish == 250 || potentialDish == 300 || potentialDish == 400)
                {
                    switch (potentialDish)
                    {
                        case 150:
                            dish = "Dipping sauce";
                            break;
                        case 250:
                            dish = "Green salad";
                            break;
                        case 300:
                            dish = "Chocolate cake";
                            break;
                        case 400:
                            dish = "Lobster";
                            break;
                    }
                    if (!madeDishes.ContainsKey(dish))
                    {
                        madeDishes[dish] = new int[]{potentialDish, 0};
                    }

                    madeDishes[dish][1]++;
                    dishCounter++;
                    ingredients.Dequeue();
                    freshnessList.Pop();
                }
                else
                {
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                    freshnessList.Pop();
                }
                
            }
            Console.WriteLine(madeDishes.Count == 4 ? $"Applause! The judges are fascinated by your dishes!" : $"You were voted off. Better luck next year.");
            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in madeDishes.OrderBy(d => d.Key))        
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value[1]}");
            }
        }
    }
}
