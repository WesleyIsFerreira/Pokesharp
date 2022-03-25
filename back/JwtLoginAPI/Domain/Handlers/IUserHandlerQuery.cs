using JwtLoginAPI.Domain.Queries.Request;
using JwtLoginAPI.Domain.Queries.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public interface IUserHandlerQuery
    {
        Task<CreateTokenLoginQueryResponse> generateToken(CreateTokenLoginQueryRequest request);
    }
}
