using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IPokemonHandlerCommand
    {
        Task<CreateItemPokemonCatalogCommandResponse> CreatePokemon(CreateItemPokemonCatalogCommandRequest request);
        Task<bool> VincPokemonAbility(AddPokemonAbilityCommandRequest request);
    }
}
