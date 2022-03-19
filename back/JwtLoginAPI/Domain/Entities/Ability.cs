using JwtLoginAPI.Domain.Comands.Entities;

namespace JwtLoginAPI.Domain.Entities
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
