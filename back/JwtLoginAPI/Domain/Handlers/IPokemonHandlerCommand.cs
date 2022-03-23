using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IPokemonHandlerCommand
    {
        Task<CreateItemPokemonCatalogResponse> CreatePokemon(CreateItemPokemonCatalogRequest request);
    }
}
