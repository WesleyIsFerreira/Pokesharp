using JwtLoginAPI.Domain.Entities;

namespace JwtLoginAPI.Domain.Queries.Response
{
    public class GetAbilitiesQueryResponse
    {
        public bool Sucesso = true;
        public List<Ability>? abilities { get; set; } = new List<Ability>();
    }
}
