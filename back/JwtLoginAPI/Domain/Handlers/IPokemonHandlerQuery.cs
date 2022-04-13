using JwtLoginAPI.Domain.Queries.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IPokemonHandlerQuery
    {
        Task<GetAbilitiesQueryResponse> ListAbilities();
        Task<GetPokemonsQueryResponse> ListPokemons();

    }
}
