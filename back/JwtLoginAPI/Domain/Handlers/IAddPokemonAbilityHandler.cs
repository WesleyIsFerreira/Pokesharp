using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IAddPokemonAbilityHandler
    {
        Task<AddPokemonAbilityResponse> AddPokemonAbility(AddPokemonAbilityRequest request);
    }
}
