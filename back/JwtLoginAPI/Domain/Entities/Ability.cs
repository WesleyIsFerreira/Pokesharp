using JwtLoginAPI.Domain.Commands.Entities;
using System.Text.Json.Serialization;

namespace JwtLoginAPI.Domain.Entities
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        [JsonIgnore]
        public List<Pokemon>? Pokemons { get; set; }
    }
}
