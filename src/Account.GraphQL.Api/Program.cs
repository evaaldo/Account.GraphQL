using Account.GraphQL.Api.GraphQL.Mutations;
using Account.GraphQL.Api.GraphQL.Queries;
using Account.GraphQL.Api.GraphQL.Queries.AccountQueries;
using Account.GraphQL.Api.GraphQL.Queries.Status;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<AccountQueries>()
    .AddTypeExtension<StatusQueries>()
    .AddMutationType<Mutation>();

builder.Services.AddSingleton<NpgsqlDataSource>(_ => NpgsqlDataSource.Create(builder.Configuration.GetConnectionString("AccountDatabase")));

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
}

app.MapGraphQL();

app.Run();
