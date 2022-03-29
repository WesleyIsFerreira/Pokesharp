using JwtLoginAPI.Domain.Commands.Entities;
using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public class PokemonHandlerCommand : IPokemonHandlerCommand
    {
        private readonly DataContext _context;
        public PokemonHandlerCommand(DataContext context)
        {
            _context = context;
        }


        public async Task<CreateItemPokemonCatalogCommandResponse> CreatePokemon(CreateItemPokemonCatalogCommandRequest request)
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

            return new CreateItemPokemonCatalogCommandResponse
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
