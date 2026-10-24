namespace Account.GraphQL.Application.DTOs.Request
{
    public record PersonRequestDto(string Name, string Email, DateTime Birthdate);
}
