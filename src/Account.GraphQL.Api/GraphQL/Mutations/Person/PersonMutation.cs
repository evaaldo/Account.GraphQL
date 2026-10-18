using Account.GraphQL.Application.DTOs.Request;
using Account.GraphQL.Application.Interfaces.UseCases;
using HotChocolate;
using HotChocolate.Types;

namespace Account.GraphQL.Api.GraphQL.Mutations.Person
{
    [ExtendObjectType(typeof(Mutation))]
    [GraphQLDescription("Provides mutations related to person types.")]
    public class PersonMutation
    {
        private readonly IPersonUseCases _personUseCase;

        public PersonMutation(IPersonUseCases personUseCase)
        {
            _personUseCase = personUseCase;
        }

        public async Task<int> CreatePerson(PersonRequestDto person)
        {
            return await _personUseCase.CreatePersonAsync(person);
        }

        public async Task UpdatePersonById(int id, PersonRequestDto person)
        {
            await _personUseCase.UpdatePersonByIdAsync(id, person);
        }

        public async Task DeletePersonById(int id)
        {
            await _personUseCase.DeletePersonByIdAsync(id);
        }
    }
}
