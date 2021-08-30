using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class PokemonTrainer
    {
        static void Main(string[] args)
        {
            string input;
            List<Trainer> pokemonTrainers = new List<Trainer>();
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] caughtPokemon = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = caughtPokemon[0];
                string pokemonName = caughtPokemon[1];
                string pokemonElement = caughtPokemon[2];
                int pokemonHealth = int.Parse(caughtPokemon[3]);
                Trainer currentTrainer = new Trainer(trainerName);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!pokemonTrainers.Exists(t => t.Name == trainerName))
                {
                    pokemonTrainers.Add(currentTrainer);
                }
                pokemonTrainers.First(t => t.Name == trainerName).Pokemons.Add(currentPokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in pokemonTrainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, pokemonTrainers.OrderByDescending(t => t.Badges)));
        }
    }
}
