using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Domain.Domain;
using Account.GraphQL.Infrastructure.ConnectionFactory;
using Dapper;

namespace Account.GraphQL.Infrastructure.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly PostgresConnectionFactory _factory;

        public StatusRepository(PostgresConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<StatusResponseDto>> ListStatusesAsync()
        {
            var sql = "SELECT * FROM tb_account_status";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync();

            return await connection.QueryAsync<StatusResponseDto>(sql);
        }

        public async Task<StatusResponseDto?> GetStatusByIdAsync(int id)
        {
            var sql = "SELECT * FROM tb_account_status WHERE id = @Id";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync();

            return await connection.QueryFirstOrDefaultAsync<StatusResponseDto>(sql, new { Id = id });
        }

        public async Task<IEnumerable<StatusResponseDto>> GetStatusesByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        {
            var sql = "SELECT * FROM tb_account_status WHERE id = ANY(@Ids)";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync(cancellationToken);

            return await connection.QueryAsync<StatusResponseDto>(sql, new { Ids = ids });
        }

        public async Task<int> CreateStatusAsync(StatusEntity status)
        {
            var sql = "INSERT INTO tb_account_status (status, description) VALUES (@Status, @Description) RETURNING id";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync();

            return await connection.QuerySingleAsync<int>(sql, new { status.Status, status.Description });
        }

        public async Task UpdateStatusByIdAsync(int id, StatusEntity status)
        {
            var sql = "UPDATE tb_account_status SET status = @Status, description = @Description WHERE id = @Id";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync();

            await connection.ExecuteAsync(sql, new { Id = id, status.Status, status.Description });
        }

        public async Task DeleteStatusByIdAsync(int id)
        {
            var sql = "DELETE FROM tb_account_status WHERE id = @Id";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync();

            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
