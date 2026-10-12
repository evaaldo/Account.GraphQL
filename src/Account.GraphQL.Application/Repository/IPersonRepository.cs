using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonEntity>> ListPersonsAsync();
        Task<PersonEntity?> GetPersonByIdAsync(int id);
        Task<int> CreatePersonAsync(PersonEntity person);
        Task UpdatePersonByIdAsync(int id, PersonEntity person);
        Task DeletePersonByIdAsync(int id);
    }
}
