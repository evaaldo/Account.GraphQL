using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Domain.Domain;
using Account.GraphQL.Infrastructure.ConnectionFactory;
using Dapper;
using Npgsql;

namespace Account.GraphQL.Infrastructure.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly PostgresConnectionFactory _factory;

        public StatusRepository(PostgresConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<StatusEntity>> ListStatusesAsync()
        {
            var sql = "SELECT * FROM tb_account_status";

            var connection = await GetOpenConnectionAsync();

            return await connection.QueryAsync<StatusEntity>(sql);
        }

        public async Task<StatusEntity?> GetStatusByIdAsync(int id)
        {
            var sql = "SELECT * FROM tb_account_status WHERE id = @Id";

            var connection = await GetOpenConnectionAsync();

            return await connection.QueryFirstOrDefaultAsync<StatusEntity>(sql, new { Id = id });
        }

        public async Task<int> CreateStatusAsync(StatusEntity status)
        {
            var sql = "INSERT INTO tb_account_status (status, description) VALUES (@Status, @Description) RETURNING id";

            var connection = await GetOpenConnectionAsync();

            return await connection.QuerySingleAsync<int>(sql, new { status.Status, status.Description });
        }

        public async Task UpdateStatusByIdAsync(int id, StatusEntity status)
        {
            var sql = "UPDATE tb_account_status SET status = @Status, description = @Description WHERE id = @Id";

            var connection = await GetOpenConnectionAsync();

            await connection.ExecuteAsync(sql, new { Id = id, status.Status, status.Description });
        }

        public async Task DeleteStatusByIdAsync(int id)
        {
            var sql = "DELETE FROM tb_account_status WHERE id = @Id";

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
