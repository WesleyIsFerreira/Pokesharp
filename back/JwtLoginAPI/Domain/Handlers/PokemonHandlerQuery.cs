using JwtLoginAPI.Domain.Queries.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public class PokemonHandlerQuery : IPokemonHandlerQuery
    {
        private readonly DataContext _context;
        private readonly IConfiguration configuration;
        public PokemonHandlerQuery(DataContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }

        public async Task<GetAbilitiesQueryResponse> ListAbilities()
        {

            var abilities = await _context.Abilities.ToListAsync();

            return new GetAbilitiesQueryResponse
            {
                abilities = abilities,
            };
        }
    }
}
