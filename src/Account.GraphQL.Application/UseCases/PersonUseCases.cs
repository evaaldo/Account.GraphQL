using Account.GraphQL.Api.DTOs.Request;
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

        public async Task<IEnumerable<PersonEntity>> ListPersonsAsync()
        {
            return await _personRepository.ListPersonsAsync();
        }

        public async Task<PersonEntity?> GetPersonByIdAsync(int id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);
            return person;
        }

        public async Task<int> CreatePersonAsync(PersonRequestDto person)
        {
            var personEntity = new PersonEntity(person.Name, person.Email, person.Birthdate);
            return await _personRepository.CreatePersonAsync(personEntity);
        }

        public async Task UpdatePersonByIdAsync(int id, PersonRequestDto person)
        {
            var personEntity = new PersonEntity(person.Name, person.Email, person.Birthdate);
            await _personRepository.UpdatePersonByIdAsync(id, personEntity);
        }

        public async Task DeletePersonByIdAsync(int id)
        {
            await _personRepository.DeletePersonByIdAsync(id);
        }
    }
}
