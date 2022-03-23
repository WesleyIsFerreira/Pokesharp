
using JwtLoginAPI.Domain.Comands.Requests;
using JwtLoginAPI.Domain.Comands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public class AddPokemonAbilityHandler : IAddPokemonAbilityHandler
    {
        private readonly DataContext _context;
        public AddPokemonAbilityHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<AddPokemonAbilityResponse> AddPokemonAbility(AddPokemonAbilityRequest request)
        {
            var ability = await _context.Abilities.FindAsync(request.AbilityId);

            var pokemon = await _context.Pokemons
                .Where(c => c.Id == request.PokemonId)
                .Include(c => c.Abilities)
                .FirstOrDefaultAsync();

            if (ability == null || pokemon == null)
            {
                return new AddPokemonAbilityResponse
                {
                    Msg = "Pokemon ou Habilidade não encontrada",
                    Success = false
                };
            }

            pokemon.Abilities.Add(ability);

            await _context.SaveChangesAsync();
            return new AddPokemonAbilityResponse
            {
                Msg = "Habilidade vinculada com Sucesso"
            };
        }
    }
}
