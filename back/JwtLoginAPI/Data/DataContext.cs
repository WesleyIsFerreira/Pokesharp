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
            var converter = new ValueConverter<Type, string>(
                    v => v.ToString(),
                    v => (Type)Enum.Parse(typeof(Type), v)
                );

                modelBuilder
                    .Entity<Pokemon>()
                    .Property(e => e.Type)
                    .HasConversion(converter);
        }

    }
}
