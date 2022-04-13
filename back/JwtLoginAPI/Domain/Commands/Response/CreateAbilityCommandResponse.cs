namespace JwtLoginAPI.Domain.Commands.Response
{
    public class CreateAbilityCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public bool Sucesso = true;
    }
}
