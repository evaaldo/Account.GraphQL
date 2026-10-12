using Npgsql;

namespace Account.GraphQL.Infrastructure.ConnectionFactory
{
    public class PostgresConnectionFactory
    {
        private readonly string _connectionString;

        public PostgresConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlDataSource CreateConnection()
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(_connectionString);
            return dataSourceBuilder.Build();
        }
    }
}
