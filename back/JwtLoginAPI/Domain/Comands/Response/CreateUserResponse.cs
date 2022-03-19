namespace JwtLoginAPI.Domain.Comands.Response
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; } = String.Empty;
    }
}
