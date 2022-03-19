using JwtLoginAPI.Domain.Queries.Request;
using JwtLoginAPI.Domain.Queries.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IUserHandlerQuery
    {
        Task<CreateTokenLoginResponse> generateToken(CreateTokenLoginRequest request);
    }
}
