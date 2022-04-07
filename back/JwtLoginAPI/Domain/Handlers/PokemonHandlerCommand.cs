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
            Pokemon newPokemon = new()
            {
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Gender = request.Gender,
                Height = request.Height,
                Weight = request.Weight,
                Type = request.Type,
                Weaknesses = request.Weaknesses
            };

            try
            {
                _context.Pokemons.Add(newPokemon);
                await _context.SaveChangesAsync();

                var pkAbility = new AddPokemonAbilityCommandRequest();
                pkAbility.AbilitiesId = request.Abilities;
                pkAbility.PokemonId = newPokemon.Id;

                bool resp = await VincPokemonAbility(pkAbility);

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

            } catch (Exception ex)
            {
                return new CreateItemPokemonCatalogCommandResponse
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }

        public async Task<bool> VincPokemonAbility(AddPokemonAbilityCommandRequest request)
        {
            var success = true;
            var list = request.AbilitiesId;

            foreach (int id in list)
            {

                var ability = await _context.Abilities.FindAsync(id);

                var pokemon = await _context.Pokemons
                    .Where(c => c.Id == request.PokemonId)
                    .Include(c => c.Abilities)
                    .FirstOrDefaultAsync();

                if (ability == null || pokemon == null)
                {
                    success = false;
                }

                pokemon.Abilities.Add(ability);
            };

            if (!success)
            {
                return false;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
