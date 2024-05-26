// Definimos el espacio de nombres para los modelos de datos de la aplicación
namespace Pokedex_MiPokemonFavorito.Models
{
    // La clase Pokemon representa un Pokémon con varias propiedades
    public class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Picture { get; set; }
        public List<string> Moves { get; set; }
    }
}