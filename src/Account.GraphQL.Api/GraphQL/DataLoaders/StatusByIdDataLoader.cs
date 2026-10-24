using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Application.Interfaces.Repository;
using GreenDonut;

namespace Account.GraphQL.Api.GraphQL.DataLoaders
{
    public class StatusByIdDataLoader : BatchDataLoader<int, StatusResponseDto?>
    {
        private readonly IStatusRepository _statusRepository;

        public StatusByIdDataLoader(IBatchScheduler scheduler, IStatusRepository statusRepository)
            : base(scheduler, new DataLoaderOptions())
        {
            _statusRepository = statusRepository;
        }

        protected override async Task<IReadOnlyDictionary<int, StatusResponseDto?>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var statuses = await _statusRepository.GetStatusesByIdsAsync(keys, cancellationToken);
            var dict = statuses.ToDictionary(s => s.Id);
            return keys.ToDictionary(id => id, id => dict.TryGetValue(id, out var s) ? s : null);
        }
    }
}
