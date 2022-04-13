using JwtLoginAPI.Domain.Commands.Entities;

namespace JwtLoginAPI.Domain.Queries.Response
{
    public class GetPokemonsQueryResponse
    {
        public bool Sucesso = true;
        public List<Pokemon>? Pokemons { get; set; } = new List<Pokemon>();
    }
}
