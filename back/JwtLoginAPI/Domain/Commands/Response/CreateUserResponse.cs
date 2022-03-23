namespace JwtLoginAPI.Domain.Commands.Response
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; } = String.Empty;
    }
}
