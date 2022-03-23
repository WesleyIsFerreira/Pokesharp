using JwtLoginAPI.Domain.Comands.Requests;
using JwtLoginAPI.Domain.Comands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IAddPokemonAbilityHandler
    {
        Task<AddPokemonAbilityResponse> AddPokemonAbility(AddPokemonAbilityRequest request);
    }
}
