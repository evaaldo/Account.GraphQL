using Account.GraphQL.Application.Interfaces.UseCases;
using Account.GraphQL.Application.UseCases;

namespace Account.GraphQL.Api.Bootstrap
{
    public static class ApplicationDependenciesExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStatusUseCases, StatusUseCases>();
            services.AddScoped<IAccountUseCases, AccountUseCases>();
            services.AddScoped<IPersonUseCases, PersonUseCases>();

            return services;
        }
    }
}
