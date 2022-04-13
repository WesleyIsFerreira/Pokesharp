using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtLoginAPI.Migrations
{
    public partial class updatepokemonPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Pokemons");
        }
    }
}
