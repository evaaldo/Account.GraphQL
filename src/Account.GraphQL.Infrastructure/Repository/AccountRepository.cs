using Account.GraphQL.Application.Repository;
using Npgsql;

namespace Account.GraphQL.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public AccountRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public Task ListAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
