using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Domain.Domain;
using Account.GraphQL.Infrastructure.ConnectionFactory;
using Dapper;

namespace Account.GraphQL.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PostgresConnectionFactory _factory;

        public PersonRepository(PostgresConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<PersonResponseDto>> ListPersonsAsync()
        {
            var sql = "SELECT * FROM tb_account_person";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync();

            return await connection.QueryAsync<PersonResponseDto>(sql);
        }

        public async Task<PersonResponseDto?> GetPersonByIdAsync(int id)
        {
            var sql = "SELECT * FROM tb_account_person WHERE id = @Id";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync();

            return await connection.QueryFirstOrDefaultAsync<PersonResponseDto>(sql, new { Id = id });
        }

        public async Task<IEnumerable<PersonResponseDto>> GetPersonsByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        {
            var sql = "SELECT * FROM tb_account_person WHERE id = ANY(@Ids)";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync(cancellationToken);

            return await connection.QueryAsync<PersonResponseDto>(sql, new { Ids = ids });
        }

        public async Task<int> CreatePersonAsync(PersonEntity person)
        {
            var sql = "INSERT INTO tb_account_person (name, email, birthdate, created_at, updated_at) VALUES (@Name, @Email, @Birthdate, @CreatedAt, @UpdatedAt) RETURNING id";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync();

            return await connection.QuerySingleAsync<int>(sql, new { person.Name, person.Email, person.Birthdate, person.CreatedAt, person.UpdatedAt });
        }

        public async Task UpdatePersonByIdAsync(int id, PersonEntity person)
        {
            var sql = "UPDATE tb_account_person SET email = @Email, updated_at = @UpdatedAt WHERE id = @Id";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync();

            await connection.ExecuteAsync(sql, new { Id = id, person.Email, person.UpdatedAt });
        }

        public async Task DeletePersonByIdAsync(int id)
        {
            var sql = "DELETE FROM tb_account_person WHERE id = @Id";

            await using var dataSource = _factory.CreateConnection();
            await using var connection = await dataSource.OpenConnectionAsync();

            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
