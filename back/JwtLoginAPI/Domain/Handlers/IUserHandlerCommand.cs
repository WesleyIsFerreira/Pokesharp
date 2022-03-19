using JwtLoginAPI.Domain.Comands.Requests;
using JwtLoginAPI.Domain.Comands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IUserHandlerCommand
    {
        Task<CreateUserResponse> CreateUser(CreateUserRequest request);
    }
}
