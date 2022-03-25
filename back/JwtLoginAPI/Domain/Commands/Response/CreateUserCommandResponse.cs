namespace JwtLoginAPI.Domain.Commands.Response
{
    public class CreateUserCommandResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; } = String.Empty;
    }
}
