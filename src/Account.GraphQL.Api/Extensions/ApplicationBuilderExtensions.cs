namespace Account.GraphQL.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static WebApplication MapApplicationEndpoints(this WebApplication app)
        {
            if (!app.Environment.IsProduction())
            {
                app.MapOpenApi();
            }

            app.MapGraphQL();

            return app;
        }
    }
}
