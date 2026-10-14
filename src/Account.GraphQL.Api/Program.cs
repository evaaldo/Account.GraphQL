using Account.GraphQL.Api.GraphQL.Mutations;
using Account.GraphQL.Api.GraphQL.Queries;
using Account.GraphQL.Api.GraphQL.Queries.AccountQueries;
using Account.GraphQL.Api.GraphQL.Queries.Status;
using Account.GraphQL.Infrastructure.ConnectionFactory;
using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Application.Interfaces.UseCases;
using Account.GraphQL.Infrastructure.Repository;
using Account.GraphQL.Application.UseCases;
using Account.GraphQL.Api.GraphQL.Queries.Person;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<AccountQueries>()
    .AddTypeExtension<StatusQueries>()
    .AddTypeExtension<PersonQueries>()
    .AddMutationType<Mutation>();

builder.Services.AddScoped(_ => new PostgresConnectionFactory(builder.Configuration.GetConnectionString("AccountDatabase")));

builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusUseCases, StatusUseCases>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountUseCases, AccountUseCases>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonUseCases, PersonUseCases>();

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
}

app.MapGraphQL();

app.Run();
