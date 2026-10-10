using Account.GraphQL.Api.GraphQL.Schemas;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
}

app.MapGraphQL();

app.Run();
