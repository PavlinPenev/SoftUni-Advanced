using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int Badges { get; set; } = 0;
        public List<Pokemon> Pokemons { get; set; }
        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
