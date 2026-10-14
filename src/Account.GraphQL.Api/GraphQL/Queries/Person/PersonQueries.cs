using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Application.Interfaces.UseCases;
using HotChocolate;
using HotChocolate.Types;

namespace Account.GraphQL.Api.GraphQL.Queries.Person
{
    [ExtendObjectType(typeof(Query))]
    [GraphQLDescription("Provides queries related to person types.")]
    public class PersonQueries
    {
        private readonly IPersonUseCases _personUseCases;

        public PersonQueries(IPersonUseCases personUseCases)
        {
            _personUseCases = personUseCases;
        }

        public async Task<IEnumerable<PersonResponseDto>> ListPersonsAsync()
        {
            return await _personUseCases.ListPersonsAsync();
        }

        public async Task<PersonResponseDto?> GetPersonByIdAsync(int id)
        {
            return await _personUseCases.GetPersonByIdAsync(id);
        }
    }
}
