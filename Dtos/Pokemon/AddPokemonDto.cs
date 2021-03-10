using pokemon_game_webApi.Models;

namespace pokemon_game_webApi.Dtos.Pokemon
{
    public class AddPokemonDto
    {
        public string Name { get; set; }
        public int Attack { get; set; } = 100;
        public int Defense { get; set; } = 100;        
        public PokemonClass PokemonClass { get; set; } = PokemonClass.Bulbasaur;
    }
}