using pokemon_game_webApi.Models;

namespace pokemon_game_webApi.Dtos.Pokemon
{
    public class UpdatePokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }              
        public PokemonClass PokemonClass { get; set; } 
    }
}