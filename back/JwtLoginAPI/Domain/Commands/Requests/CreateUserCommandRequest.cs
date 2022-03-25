namespace JwtLoginAPI.Domain.Commands.Requests
{
    public class CreateUserCommandRequest
    {
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
