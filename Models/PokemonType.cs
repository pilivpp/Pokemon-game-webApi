namespace pokemon_game_webApi.Models
{
    public class PokemonType
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}