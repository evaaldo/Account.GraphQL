using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Application.Interfaces.Repository;
using GreenDonut;

namespace Account.GraphQL.Api.GraphQL.DataLoaders
{
    public class PersonByIdDataLoader : BatchDataLoader<int, PersonResponseDto?>
    {
        private readonly IPersonRepository _personRepository;

        public PersonByIdDataLoader(IBatchScheduler scheduler, IPersonRepository personRepository)
            : base(scheduler, new DataLoaderOptions())
        {
            _personRepository = personRepository;
        }

        protected override async Task<IReadOnlyDictionary<int, PersonResponseDto?>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.GetPersonsByIdsAsync(keys, cancellationToken);
            var dict = persons.ToDictionary(p => p.Id);
            return keys.ToDictionary(id => id, id => dict.TryGetValue(id, out var p) ? p : null);
        }
    }
}
