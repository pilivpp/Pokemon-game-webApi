using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pokemon_game_webApi.Dtos.Pokemon;
using pokemon_game_webApi.Services.PokemonService;

namespace pokemon_game_webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _service;
        public PokemonController(IPokemonService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddPokemon(AddPokemonDto newPokemon)
        {
            return Ok(await _service.AddPokemon(newPokemon));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            return Ok(await _service.DeletePokemon(id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPokemons()
        {
            return Ok(await _service.GetAllPokemons());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemon(int id)
        {
            return Ok(await _service.GetPokemon(id));
        }        
        [HttpPut()]
        public async Task<IActionResult> UpdatePokemon(UpdatePokemonDto updatePokemon)
        {
            return Ok(await _service.UpdatePokemon(updatePokemon));
        }          
    }
}