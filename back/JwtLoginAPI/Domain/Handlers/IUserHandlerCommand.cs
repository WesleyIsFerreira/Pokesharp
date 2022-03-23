using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IUserHandlerCommand
    {
        Task<CreateUserResponse> CreateUser(CreateUserRequest request);
    }
}
