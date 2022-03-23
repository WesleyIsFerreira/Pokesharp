namespace JwtLoginAPI.Domain.Comands.Response
{
    public class AddPokemonAbilityResponse
    {
        public string Errors { get; set; } = string.Empty;
        public string Msg { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
    }
}
