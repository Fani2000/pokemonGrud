using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Dto;
using PokemonApp.Models;
using PokemonReviewApp;

namespace PokemonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int id)
        {
            if (!_pokemonRepository.PokemonExists(id))
                return NotFound();

            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }
        [HttpGet("{pokemonId}/rating")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokemonId)
        {

            if (!_pokemonRepository.PokemonExists(pokemonId))
                return NotFound();


            var rating = _pokemonRepository.getPokemonRating(pokemonId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }
    }
}