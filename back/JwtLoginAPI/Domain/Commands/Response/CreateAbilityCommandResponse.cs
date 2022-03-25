namespace JwtLoginAPI.Domain.Commands.Response
{
    public class CreateAbilityCommandResponse
    {
        public int Id { get; set; }
        public string name { get; set; } = String.Empty;
        public string description { get; set; } = String.Empty;
    }
}
