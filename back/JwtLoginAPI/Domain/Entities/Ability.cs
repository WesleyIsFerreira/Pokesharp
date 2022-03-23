using JwtLoginAPI.Domain.Commands.Entities;

namespace JwtLoginAPI.Domain.Entities
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public List<Pokemon>? Pokemons { get; set; }
    }
}
