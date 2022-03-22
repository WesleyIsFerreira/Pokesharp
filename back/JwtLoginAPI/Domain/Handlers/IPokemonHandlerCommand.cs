using JwtLoginAPI.Domain.Comands.Requests;
using JwtLoginAPI.Domain.Comands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IPokemonHandlerCommand
    {
        Task<CreateItemPokemonCatalogResponse> CreatePokemon(CreateItemPokemonCatalogRequest request);
    }
}
