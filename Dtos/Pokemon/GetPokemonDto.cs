using pokemon_game_webApi.Models;

namespace pokemon_game_webApi.Dtos.Pokemon
{
    public class GetPokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }        
        public User User { get; set; }
        public PokemonClass PokemonClass { get; set; } 
    }
}