namespace Account.GraphQL.Application.DTOs.Response
{
    public record AccountResponseDto(int Id, int IdPerson, int IdStatus, DateTime CreatedAt, DateTime UpdatedAt);
}
