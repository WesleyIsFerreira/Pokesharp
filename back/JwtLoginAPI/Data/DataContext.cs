using JwtLoginAPI.Domain.Comands.Entities;
using JwtLoginAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
    }
}
