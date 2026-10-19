using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.Interfaces.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonResponseDto>> ListPersonsAsync();
        Task<PersonResponseDto?> GetPersonByIdAsync(int id);
        Task<IEnumerable<PersonResponseDto>> GetPersonsByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default);
        Task<int> CreatePersonAsync(PersonEntity person);
        Task UpdatePersonByIdAsync(int id, PersonEntity person);
        Task DeletePersonByIdAsync(int id);
    }
}
