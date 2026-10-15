namespace Account.GraphQL.Application.DTOs.Request
{
    public record StatusRequestDto(string Status, string Description, bool IsActive);
}
