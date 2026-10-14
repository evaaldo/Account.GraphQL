using Account.GraphQL.Api.DTOs.Request;

namespace Account.GraphQL.Application.DTOs.Request
{
    public record AccountRequestDto(int IdStatus, PersonRequestDto person);
}
