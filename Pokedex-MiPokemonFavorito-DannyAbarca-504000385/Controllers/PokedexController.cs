// Importamos las bibliotecas necesarias
using Microsoft.AspNetCore.Mvc; 
using Pokedex_MiPokemonFavorito.Services; 
using System.Threading.Tasks;

namespace Pokedex_MiPokemonFavorito.Controllers
{
    [ApiController] // Indica que esta clase es un controlador de API
    [Route("api/[controller]")] // Define la ruta base para este controlador
    public class PokedexController : ControllerBase
    {
        private readonly PokedexServices _pokedexServices;
        private readonly ILogger<PokedexController> _logger;

        // Constructor que recibe los servicios de la Pokedex y el logger
        public PokedexController(PokedexServices pokedexServices, ILogger<PokedexController> logger)
        {
            _pokedexServices = pokedexServices;
            _logger = logger;
        }

        // Acción HTTP GET que recibe un nombre de Pokémon y devuelve su información
        [HttpGet(Name = "PokemonAPI")]
        public async Task<IActionResult> GetPokemon(string name)
        {
            // Llamamos al servicio para obtener la información del Pokémon
            var pokemon = await _pokedexServices.GetPokemonAsync(name);
            if (pokemon == null)
            {
                
                return NotFound();
            }
            
            return Ok(pokemon);
        }

        // Acción HTTP GET específica para obtener información de Chikorita
        [HttpGet("Chikorita")]
        public async Task<IActionResult> GetChikorita()
        {
            // Llamamos al servicio para obtener la información de Chikorita
            var pokemon = await _pokedexServices.GetPokemonAsync("Chikorita");
            if (pokemon == null)
            {
                
                return NotFound();
            }
            
            return Ok(pokemon);
        }
    }
}
