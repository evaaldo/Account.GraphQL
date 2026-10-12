using Account.GraphQL.Api.DTOs.Request;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.Interfaces.UseCases
{
    public interface IPersonUseCases
    {
        Task<IEnumerable<PersonEntity>> ListPersonsAsync();
        Task<PersonEntity?> GetPersonByIdAsync(int id);
        Task<int> CreatePersonAsync(PersonRequestDto personRequest);
        Task UpdatePersonByIdAsync(int id, PersonRequestDto personRequest);
        Task DeletePersonByIdAsync(int id);
    }
}
