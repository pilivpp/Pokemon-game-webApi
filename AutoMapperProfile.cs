using AutoMapper;
using pokemon_game_webApi.Dtos.Pokemon;
using pokemon_game_webApi.Models;

namespace pokemon_game_webApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddPokemonDto, Pokemon>();
            CreateMap<Pokemon, GetPokemonDto>();
        }
    }
}