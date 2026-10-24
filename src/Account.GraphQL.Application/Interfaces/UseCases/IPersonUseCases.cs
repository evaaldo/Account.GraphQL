using Account.GraphQL.Application.DTOs.Request;
using Account.GraphQL.Application.DTOs.Response;

namespace Account.GraphQL.Application.Interfaces.UseCases
{
    public interface IPersonUseCases
    {
        Task<IEnumerable<PersonResponseDto>> ListPersonsAsync();
        Task<PersonResponseDto?> GetPersonByIdAsync(int id);
        Task<int> CreatePersonAsync(PersonRequestDto personRequest);
        Task UpdatePersonByIdAsync(int id, PersonRequestDto personRequest);
        Task DeletePersonByIdAsync(int id);
    }
}
