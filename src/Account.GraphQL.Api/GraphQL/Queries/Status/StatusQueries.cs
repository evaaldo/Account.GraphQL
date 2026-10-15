using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Application.Interfaces.UseCases;
using HotChocolate;
using HotChocolate.Types;

namespace Account.GraphQL.Api.GraphQL.Queries.Status
{
    [ExtendObjectType(typeof(Query))]
    [GraphQLDescription("Provides queries related to status types.")]
    public class StatusQueries
    {
        private readonly IStatusUseCases _statusUseCases;

        public StatusQueries(IStatusUseCases statusUseCases)
        {
            _statusUseCases = statusUseCases;
        }

        public async Task<IEnumerable<StatusResponseDto>> GetStatus()
        {
            return await _statusUseCases.ListStatusesAsync();
        }
    }
}
