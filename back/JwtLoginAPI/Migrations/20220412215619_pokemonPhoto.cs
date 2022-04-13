using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtLoginAPI.Migrations
{
    public partial class pokemonPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Pokemons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Pokemons",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
