using JwtLoginAPI.Domain.Entities;

namespace JwtLoginAPI.Domain.Commands.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
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

    public enum Genders
    {
        both,
        masculine,
        female,
        unknown
    }

    public enum Types
    {
        Normal,
        Fire,
        Water,
        Grass,
        Flying,
        Fighting,
        Poison,
        Electric,
        Ground,
        Rock,
        Psychic,
        Ice,
        Bug,
        Ghost,
        Steel,
        Dragon,
        Dark,
        Fairy
    }

}
