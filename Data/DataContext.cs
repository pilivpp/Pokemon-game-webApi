using Microsoft.EntityFrameworkCore;
using pokemon_game_webApi.Models;

namespace pokemon_game_webApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }        
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<User> Users { get; set; }
    }
}