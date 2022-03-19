namespace JwtLoginAPI.Domain.Comands.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
