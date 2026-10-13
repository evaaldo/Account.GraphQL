namespace Account.GraphQL.Application.DTOs.Response
{
    public record PersonResponseDto(int Id, string Name, string Email, DateTime Birthdate, DateTime CreatedAt, DateTime UpdatedAt);
}
