using Account.GraphQL.Application.DTOs.Request;
using Account.GraphQL.Application.Interfaces.UseCases;
using HotChocolate;
using HotChocolate.Types;

namespace Account.GraphQL.Api.GraphQL.Mutations.Status
{
    [ExtendObjectType(typeof(Mutation))]
    [GraphQLDescription("Provides mutations related to status types.")]
    public class StatusMutation
    {
        private readonly IStatusUseCases _statusUseCase;

        public StatusMutation(IStatusUseCases statusUseCase)
        {
            _statusUseCase = statusUseCase;
        }

        public async Task<int> CreateStatus(StatusRequestDto status)
        {
            return await _statusUseCase.CreateStatusAsync(status);
        }

        public async Task UpdateStatusById(int id, StatusRequestDto status)
        {
            await _statusUseCase.UpdateStatusByIdAsync(id, status);
        }

        public async Task DeleteStatusById(int id)
        {
            await _statusUseCase.DeleteStatusByIdAsync(id);
        }
    }
}
