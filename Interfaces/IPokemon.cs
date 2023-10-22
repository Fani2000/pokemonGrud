using PokemonApp.Models;

namespace PokemonReviewApp;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemons();
    Pokemon GetPokemon(int id);
    Pokemon GetPokemon(string name);
    decimal getPokemonRating(int pokemonId);

    bool PokemonExists(int pokemonId);
}