using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Domain.Domain;
using Account.GraphQL.Infrastructure.ConnectionFactory;
using Dapper;
using Npgsql;

namespace Account.GraphQL.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PostgresConnectionFactory _factory;

        public PersonRepository(PostgresConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<PersonEntity>> ListPersonsAsync()
        {
            var sql = "SELECT * FROM tb_account_person";

            var connection = await GetOpenConnectionAsync();

            return await connection.QueryAsync<PersonEntity>(sql);
        }

        public async Task<PersonEntity?> GetPersonByIdAsync(int id)
        {
            var sql = "SELECT * FROM tb_account_person WHERE id = @Id";

            var connection = await GetOpenConnectionAsync();

            return await connection.QueryFirstOrDefaultAsync<PersonEntity>(sql, new { Id = id });
        }

        public async Task<int> CreatePersonAsync(PersonEntity person)
        {
            var sql = "INSERT INTO tb_account_person (name, email, birthdate, created_at, updated_at) VALUES (@Name, @Email, @Birthdate, @CreatedAt, @UpdatedAt) RETURNING id";

            var connection = await GetOpenConnectionAsync();

            return await connection.QuerySingleAsync<int>(sql, new { person.Name, person.Email, person.Birthdate, person.CreatedAt, person.UpdatedAt });
        }

        public async Task UpdatePersonByIdAsync(int id, PersonEntity person)
        {
            var sql = "UPDATE tb_account_person SET email = @Email, updated_at = @UpdatedAt WHERE id = @Id";

            var connection = await GetOpenConnectionAsync();

            await connection.ExecuteAsync(sql, new { Id = id, person.Email, person.UpdatedAt });
        }

        public async Task DeletePersonByIdAsync(int id)
        {
            var sql = "DELETE FROM tb_account_person WHERE id = @Id";

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
