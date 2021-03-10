using Microsoft.EntityFrameworkCore.Migrations;

namespace pokemon_game_webApi.Migrations
{
    public partial class PokemonClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonClass",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokemonClass",
                table: "Pokemons");
        }
    }
}
