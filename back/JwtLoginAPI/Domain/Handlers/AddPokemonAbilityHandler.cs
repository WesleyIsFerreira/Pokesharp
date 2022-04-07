
using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public class AddPokemonAbilityHandler : IAddPokemonAbilityHandler
    {
        private readonly DataContext _context;
        public AddPokemonAbilityHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<AddPokemonAbilityCommandResponse> AddPokemonAbility(AddPokemonAbilityCommandRequest request)
        {
            var success = true;

            request.AbilitiesId.ForEach(async delegate (int id)
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
            });

            if (!success)
            {
                return new AddPokemonAbilityCommandResponse
                {
                    Msg = "Pokemon ou Habilidade não encontrada",
                    Success = false
                };
            }

            await _context.SaveChangesAsync();
            return new AddPokemonAbilityCommandResponse
            {
                Msg = "Habilidade vinculada com Sucesso"
            };
        }
    }
}
