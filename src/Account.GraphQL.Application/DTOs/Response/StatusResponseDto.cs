namespace Account.GraphQL.Application.DTOs.Response
{
    public record StatusResponseDto(int Id, string Status, string Description, bool IsActive);
}
