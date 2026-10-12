using Account.GraphQL.Application.Repository;
using Account.GraphQL.Domain.Domain;
using Npgsql;

namespace Account.GraphQL.Infrastructure.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public StatusRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
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
