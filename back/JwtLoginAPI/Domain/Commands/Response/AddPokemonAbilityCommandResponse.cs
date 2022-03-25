namespace JwtLoginAPI.Domain.Commands.Response
{
    public class AddPokemonAbilityCommandResponse
    {
        public string Errors { get; set; } = string.Empty;
        public string Msg { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
    }
}
