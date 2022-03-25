namespace JwtLoginAPI.Domain.Queries.Request
{
    public class CreateTokenLoginQueryRequest
    {
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
