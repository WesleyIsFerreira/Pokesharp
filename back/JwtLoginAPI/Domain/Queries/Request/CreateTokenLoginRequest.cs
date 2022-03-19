namespace JwtLoginAPI.Domain.Queries.Request
{
    public class CreateTokenLoginRequest
    {
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
