using Account.GraphQL.Api.GraphQL.Mutations;
using Account.GraphQL.Api.GraphQL.Mutations.Account;
using Account.GraphQL.Api.GraphQL.Mutations.Person;
using Account.GraphQL.Api.GraphQL.Mutations.Status;
using Account.GraphQL.Api.GraphQL.Queries;
using Account.GraphQL.Api.GraphQL.Queries.AccountQueries;
using Account.GraphQL.Api.GraphQL.Queries.Person;
using Account.GraphQL.Api.GraphQL.Queries.Status;

namespace Account.GraphQL.Api.Bootstrap
{
    public static class GraphQLConfigurationExtensions
    {
        public static IServiceCollection AddGraphQLConfiguration(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddTypeExtension<AccountQueries>()
                .AddTypeExtension<StatusQueries>()
                .AddTypeExtension<PersonQueries>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<AccountMutation>()
                .AddTypeExtension<StatusMutation>()
                .AddTypeExtension<PersonMutation>();
            return services;
        }
    }
}
