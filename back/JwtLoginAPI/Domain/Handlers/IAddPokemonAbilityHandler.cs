using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IAddPokemonAbilityHandler
    {
        Task<AddPokemonAbilityCommandResponse> AddPokemonAbility(AddPokemonAbilityCommandRequest request);
    }
}
