using System.Collections.Generic;

namespace pokemon_game_webApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}