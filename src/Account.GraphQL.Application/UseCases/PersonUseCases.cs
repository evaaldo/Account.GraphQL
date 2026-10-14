using Account.GraphQL.Api.DTOs.Request;
using Account.GraphQL.Application.DTOs.Response;
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

        public async Task<IEnumerable<PersonResponseDto>> ListPersonsAsync()
        {
            return await _personRepository.ListPersonsAsync();
        }

        public async Task<PersonResponseDto?> GetPersonByIdAsync(int id)
        {
            return await _personRepository.GetPersonByIdAsync(id);
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
