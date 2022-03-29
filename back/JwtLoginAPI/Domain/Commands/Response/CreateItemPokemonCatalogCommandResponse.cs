using JwtLoginAPI.Domain.Commands.Entities;
using JwtLoginAPI.Domain.Entities;

namespace JwtLoginAPI.Domain.Commands.Response
{
    public class CreateItemPokemonCatalogCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public Gender Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public ICollection<string>? Type { get; set; }
        public ICollection<string>? Weaknesses { get; set; }
        public List<Ability>? Abilities { get; set; }
    }
}
