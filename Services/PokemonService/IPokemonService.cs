using System.Collections.Generic;
using System.Threading.Tasks;
using pokemon_game_webApi.Dtos.Pokemon;

namespace pokemon_game_webApi.Services.PokemonService
{
    public interface IPokemonService
    {
        Task<ServiceResponse<GetPokemonDto>> AddPokemon(AddPokemonDto newPokemon);
        Task<ServiceResponse<List<GetPokemonDto>>> GetAllPokemons();
        Task<ServiceResponse<GetPokemonDto>> GetPokemon(int id);
        Task<ServiceResponse<GetPokemonDto>> UpdatePokemon(UpdatePokemonDto updatePokemon);
        Task<ServiceResponse<GetPokemonDto>> DeletePokemon(int id);
        
    }
}