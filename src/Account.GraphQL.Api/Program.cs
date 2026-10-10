using Account.GraphQL.Api.GraphQL.Mutations;
using Account.GraphQL.Api.GraphQL.Queries;
using Account.GraphQL.Api.GraphQL.Queries.AccountQueries;
using Account.GraphQL.Api.GraphQL.Queries.Status;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<AccountQueries>()
    .AddTypeExtension<StatusQueries>();
    //.AddMutationType<Mutation>();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
}

app.MapGraphQL();

app.Run();
