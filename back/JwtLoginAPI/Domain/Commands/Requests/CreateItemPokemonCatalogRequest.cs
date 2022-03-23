using JwtLoginAPI.Domain.Commands.Entities;
using JwtLoginAPI.Domain.Entities;

namespace JwtLoginAPI.Domain.Commands.Requests
{
    public class CreateItemPokemonCatalogRequest
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public Genders Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public Types Type { get; set; }
        public Types Weaknesses { get; set; }
        public List<Ability>? Abilities { get; set; }
    }
}
