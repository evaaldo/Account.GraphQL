namespace Account.GraphQL.Api.DTOs.Request
{
    public class CreatePersonRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
    }
}
