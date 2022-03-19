namespace JwtLoginAPI.Domain.Comands.Response
{
    public class CreateAbilitiesResponse
    {
        public int Id { get; set; }
        public string name { get; set; } = String.Empty;
        public string description { get; set; } = String.Empty;
    }
}
