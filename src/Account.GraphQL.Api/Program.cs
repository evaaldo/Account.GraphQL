using Account.GraphQL.Api.Bootstrap;
using Account.GraphQL.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddGraphQLConfiguration();
builder.Services.AddInfrastructureDependencies(builder.Configuration);
builder.Services.AddApplicationDependencies();

var app = builder.Build();

app.MapApplicationEndpoints();

app.Run();
