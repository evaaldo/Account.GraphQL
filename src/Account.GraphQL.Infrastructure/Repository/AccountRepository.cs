using Account.GraphQL.Application.Repository;
using Account.GraphQL.Domain.Domain;
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

        public Task<IEnumerable<AccountEntity>> ListAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccountEntity?> GetAccountByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAccountAsync(AccountEntity account)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccountByIdAsync(int id, AccountEntity account)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccountByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
