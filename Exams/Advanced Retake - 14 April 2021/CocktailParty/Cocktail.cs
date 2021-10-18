using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public  IReadOnlyList<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(i => i.Alcohol);
        public void Add(Ingredient ingredient)
        {
            List<Ingredient> ingredients = Ingredients.ToList();
            if (!ingredients.Any(i => i.Name == ingredient.Name) && Ingredients.Count + 1 <= Capacity && CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcoholLevel)
            {
                ingredients.Add(ingredient);
            }
            Ingredients = ingredients;
        }

        public bool Remove(string name)
        {
            Ingredient ingredientToRemove = Ingredients.FirstOrDefault(i => i.Name == name);
            if (ingredientToRemove == null)
            {
                return false;
            }

            List<Ingredient> ingredients = Ingredients.ToList();
            ingredients.Remove(ingredientToRemove);
            Ingredients = ingredients.AsReadOnly();
            return true;
        }

        public Ingredient FindIngredient(string name)
            => Ingredients.FirstOrDefault(i => i.Name == name);

        public Ingredient GetMostAlcoholicIngredient()
            => Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
