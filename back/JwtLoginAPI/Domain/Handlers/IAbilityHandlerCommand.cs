using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IAbilityHandlerCommand
    {
        Task<CreateAbilityCommandResponse> CreateAbility(CreateAbilityCommandRequest request);
    }
}
