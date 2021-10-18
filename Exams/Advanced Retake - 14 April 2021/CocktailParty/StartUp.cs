namespace CocktailParty
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Sample Code Usage:

            //Initialize Cocktail
            Cocktail cocktail = new Cocktail("Pina Colada", 3, 10);

            //Initialize Ingredient
            Ingredient rum = new Ingredient("Rum", 2, 3);

            //Print rum
            Console.WriteLine(rum.ToString());

            //Ingredient: Rum
            //Quantity: 3
            //Alcohol: 2

            //Add rum
            cocktail.Add(rum);

            //Remove rum
            Console.WriteLine(cocktail.Remove("Rum")); // true
            Ingredient vodka = new Ingredient("Vodka", 2, 5);
            Ingredient milk = new Ingredient("Milk", 0, 5);

            //Add ingredients
            cocktail.Add(vodka);
            cocktail.Add(milk);

            //GetMostAlcoholicIngredient
            Console.WriteLine(cocktail.GetMostAlcoholicIngredient());
            //Ingredient: Vodka
            //Quantity: 5
            //Alcohol: 2

            //CurrentAlcoholLevel
            Console.WriteLine(cocktail.CurrentAlcoholLevel);
            //2

            //Print Cocktail report
            Console.WriteLine(cocktail.Report());

            //Cocktail: Pina Colada - Current Alcohol Level: 2
            //Ingredient: Vokda
            //Quantity: 5
            //Alcohol: 2
            //Ingredient: Milk
            //Quantity: 5
            //Alcohol: 0

        }
    }
}
