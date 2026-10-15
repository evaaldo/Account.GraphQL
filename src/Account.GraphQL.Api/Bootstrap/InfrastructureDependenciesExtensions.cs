using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Infrastructure.ConnectionFactory;
using Account.GraphQL.Infrastructure.Repository;

namespace Account.GraphQL.Api.Bootstrap
{
    public static class InfrastructureDependenciesExtensions
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(_ => new PostgresConnectionFactory(configuration.GetConnectionString("AccountDatabase") ?? throw new ArgumentNullException("Connection string 'AccountDatabase' não configurada.")));

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            return services;
        }
    }
}
