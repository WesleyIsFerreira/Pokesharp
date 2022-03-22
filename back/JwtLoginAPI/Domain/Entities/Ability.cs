using JwtLoginAPI.Domain.Comands.Entities;
using System.ComponentModel.DataAnnotations.Schema;

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
