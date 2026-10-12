using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Application.Interfaces.UseCases;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.UseCases
{
    public class PersonUseCases : IPersonUseCases
    {
        private readonly IPersonRepository _personRepository;

        public PersonUseCases(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<IEnumerable<PersonEntity>> ListPersonsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonEntity?> GetPersonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreatePersonAsync(PersonEntity person)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonByIdAsync(int id, PersonEntity person)
        {
            throw new NotImplementedException();
        }

        public Task DeletePersonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
