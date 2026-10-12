using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Application.Interfaces.UseCases;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.UseCases
{
    public class StatusUseCases : IStatusUseCases
    {
        private readonly IStatusRepository _statusRepository;

        public StatusUseCases(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public Task<IEnumerable<StatusEntity>> ListStatusesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StatusEntity?> GetStatusByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateStatusAsync(StatusEntity status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatusByIdAsync(int id, StatusEntity status)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStatusByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
