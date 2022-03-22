using JwtLoginAPI.Domain.Comands.Entities;
using JwtLoginAPI.Domain.Comands.Requests;
using JwtLoginAPI.Domain.Comands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public class PokemonHandlerCommand : IPokemonHandlerCommand
    {
        private readonly DataContext _context;
        public PokemonHandlerCommand(DataContext context)
        {
            _context = context;
        }


        public async Task<CreateItemPokemonCatalogResponse> CreatePokemon(CreateItemPokemonCatalogRequest request)
        {
            Pokemon newPokemon = new Pokemon();
            newPokemon.Name = request.Name;
            newPokemon.Description = request.Description;
            newPokemon.Category = request.Category;
            newPokemon.Gender = request.Gender;
            newPokemon.Height = request.Height;
            newPokemon.Weight = request.Weight;
            newPokemon.Type = request.Type;
            newPokemon.Weaknesses = request.Weaknesses;

            _context.Pokemons.Add(newPokemon);
            await _context.SaveChangesAsync();

            return new CreateItemPokemonCatalogResponse
            {
                Id = newPokemon.Id,
                Description = newPokemon.Description,
                Category = newPokemon.Category,
                Gender = newPokemon.Gender,
                Height = newPokemon.Height,
                Weight = newPokemon.Weight,
                Type = newPokemon.Type,
                Weaknesses = newPokemon.Weaknesses
            };
        }
    }
}
