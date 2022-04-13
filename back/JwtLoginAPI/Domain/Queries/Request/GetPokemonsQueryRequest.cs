namespace JwtLoginAPI.Domain.Queries.Request
{
    public class GetPokemonsQueryRequest
    {
        public string Name { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public List<int>? Type { get; set; }
        public List<int>? Weaknesses { get; set; }
        public List<int>? AbilitiesId { get; set; }
    }
}
