// Importamos las bibliotecas necesarias
using Newtonsoft.Json.Linq;
using Pokedex_MiPokemonFavorito.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Pokedex_MiPokemonFavorito.Services
{
    // Definimos la clase de servicios de la Pokedex
    public class PokedexServices
    {
        private readonly HttpClient _httpClient;

        // Constructor que recibe una instancia de HttpClient
        public PokedexServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método asincrónico para obtener un Pokémon por su nombre
        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            try
            {
                // Realizamos la solicitud HTTP GET a la API de Pokémon
                var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");

                // Verificamos si la respuesta es exitosa
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error retrieving data from API: {response.ReasonPhrase}");
                }

                // Parseamos la respuesta JSON
                var json = JObject.Parse(await response.Content.ReadAsStringAsync());

                // Creamos una instancia de la clase Pokemon
                var pokemon = new Pokemon
                {
                    Name = json["name"]?.ToString(),
                    Type = json["types"]?[0]?["type"]?["name"]?.ToString(), 
                    Picture = json["sprites"]?["front_default"]?.ToString(),
                    Moves = json["moves"]?.Select(m => m["move"]?["name"]?.ToString()).ToList() 
                };
                return pokemon;
            }
            catch (HttpRequestException ex)
            {
                // Manejo de errores HTTP
                throw new Exception("Error fetching data from the Pokémon API", ex);
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otro tipo de error
                throw new Exception("An error occurred while processing the Pokémon data", ex);
            }
        }
    }
}

