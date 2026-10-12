using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Domain.Domain;
using Account.GraphQL.Infrastructure.ConnectionFactory;
using Dapper;
using Npgsql;

namespace Account.GraphQL.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PostgresConnectionFactory _factory;

        public AccountRepository(PostgresConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<AccountEntity>> ListAccountsAsync()
        {
            var sql = "SELECT * FROM tb_account";

            var connection = await GetOpenConnectionAsync();

            return await connection.QueryAsync<AccountEntity>(sql);
        }

        public async Task<AccountEntity?> GetAccountByIdAsync(int id)
        {
            var sql = "SELECT * FROM tb_account WHERE id = @Id";

            var connection = await GetOpenConnectionAsync();

            return await connection.QueryFirstOrDefaultAsync<AccountEntity>(sql, new { Id = id });
        }

        public async Task<int> CreateAccountAsync(AccountEntity account)
        {
            var sql = "INSERT INTO tb_account (id_person, id_status, created_at, updated_at) VALUES (@IdPerson, @IdStatus, @CreatedAt, @UpdatedAt) RETURNING id";

            var connection = await GetOpenConnectionAsync();

            return await connection.QuerySingleAsync<int>(sql, new { account.IdPerson, account.IdStatus, account.CreatedAt, account.UpdatedAt });
        }

        public async Task UpdateAccountByIdAsync(int id, AccountEntity account)
        {
            var sql = "UPDATE tb_account SET id_status = @IdStatus, updated_at = @UpdatedAt WHERE id = @Id";

            var connection = await GetOpenConnectionAsync();

            await connection.ExecuteAsync(sql, new { Id = id, account.IdStatus, account.UpdatedAt });
        }

        public async Task DeleteAccountByIdAsync(int id)
        {
            var sql = "DELETE FROM tb_account WHERE id = @Id";

            var connection = await GetOpenConnectionAsync();

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        private async Task<NpgsqlConnection> GetOpenConnectionAsync()
        {
            await using var dataSource = _factory.CreateConnection();
            using var connection = await dataSource.OpenConnectionAsync();
            return connection;
        }
    }
}
