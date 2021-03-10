using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pokemon_game_webApi.Data;
using pokemon_game_webApi.Dtos.Pokemon;
using pokemon_game_webApi.Models;

namespace pokemon_game_webApi.Services.PokemonService
{
    public class PokemonService : IPokemonService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PokemonService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetPokemonDto>> AddPokemon(AddPokemonDto newPokemon)
        {
            ServiceResponse<GetPokemonDto> serviceResponse = new ServiceResponse<GetPokemonDto>();
            Pokemon pokemon = _mapper.Map<Pokemon>(newPokemon);

            try
            {
                await _context.Pokemons.AddAsync(pokemon);
                await _context.SaveChangesAsync();
                serviceResponse.Message = "Pokemon added successfully";
            }
            catch
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Pokemon not added";
            }
            serviceResponse.Data = _mapper.Map<GetPokemonDto>(pokemon);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPokemonDto>> DeletePokemon(int id)
        {
            ServiceResponse<GetPokemonDto> serviceResponse = new ServiceResponse<GetPokemonDto>();
            Pokemon pokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == id);
            try
            {
                if(pokemon.Id == id)
                {
                    _context.Pokemons.Remove(pokemon);
                    await _context.SaveChangesAsync();
                    serviceResponse.Message = "Pokemon deleted";
                }
            }
            catch
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Pokemon not found";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPokemonDto>>> GetAllPokemons()
        {
            ServiceResponse<List<GetPokemonDto>> serviceResponse = new ServiceResponse<List<GetPokemonDto>>();
            List<Pokemon> dbPokemon = await _context.Pokemons.ToListAsync();
            serviceResponse.Data = dbPokemon.Select(p => _mapper.Map<GetPokemonDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPokemonDto>> GetPokemon(int id)
        {
            ServiceResponse<GetPokemonDto> serviceResponse = new ServiceResponse<GetPokemonDto>();
            
            Pokemon pokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == id);
            try
            {
                if(pokemon.Id == id)
                {
                    serviceResponse.Data = _mapper.Map<GetPokemonDto>(pokemon);
                    serviceResponse.Message = "Pokemon found";
                }
            }
            catch
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Pokemon not found";
            }
            return serviceResponse;            
        }

        public async Task<ServiceResponse<GetPokemonDto>> UpdatePokemon(UpdatePokemonDto updatePokemon)
        {
            ServiceResponse<GetPokemonDto> serviceResponse = new ServiceResponse<GetPokemonDto>();
            Pokemon pokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == updatePokemon.Id);
            try
            {
                if(pokemon.Id == updatePokemon.Id)
                {
                    pokemon.Name = updatePokemon.Name;
                    pokemon.Attack = updatePokemon.Attack;
                    pokemon.Defense = updatePokemon.Defense;
                    pokemon.PokemonClass = pokemon.PokemonClass;

                    _context.Pokemons.Update(pokemon);
                    await _context.SaveChangesAsync();

                    serviceResponse.Message = "Pokemon updated";
                    serviceResponse.Data = _mapper.Map<GetPokemonDto>(pokemon);
                }
            }
            catch
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Pokemon not found";
            }
            return serviceResponse;   
        }
    }
}