namespace JwtLoginAPI.Domain.Commands.Requests
{
    public class AddPokemonAbilityCommandRequest
    {
        public int PokemonId { get; set; }
        public List<int>? AbilitiesId { get; set; }
    }
}
