using JwtLoginAPI.Domain.Comands.Requests;
using JwtLoginAPI.Domain.Comands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IAbilityHandlerCommand
    {
        Task<CreateAbilityResponse> CreateAbility(CreateAbilityRequest request);
    }
}
