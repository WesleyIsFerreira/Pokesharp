namespace JwtLoginAPI.Domain.Comands.Requests
{
    public class AddPokemonAbilityRequest
    {
        public int PokemonId { get; set; }
        public int AbilityId { get; set; }
    }
}
