using JwtLoginAPI.Domain.Comands.Entities;
using JwtLoginAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JwtLoginAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Pokemon>()
            .Property(e => e.Gender)
            .HasConversion(
                v => v.ToString(),
                v => (Genders)Enum.Parse(typeof(Genders), v));

            modelBuilder
            .Entity<Pokemon>()
            .Property(e => e.Type)
            .HasConversion(
                v => v.ToString(),
                v => (Types)Enum.Parse(typeof(Types), v));

            modelBuilder
            .Entity<Pokemon>()
            .Property(e => e.Weaknesses)
            .HasConversion(
                v => v.ToString(),
                v => (Types)Enum.Parse(typeof(Types), v));
        }

    }
}
