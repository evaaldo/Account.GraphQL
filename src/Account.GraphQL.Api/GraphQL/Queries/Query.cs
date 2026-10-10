using HotChocolate;

namespace Account.GraphQL.Api.GraphQL.Queries
{
    public class Query
    {
        [GraphQLDeprecated("This query is deprecated")]
        public string Instructions => "Arrocha esse GraphQL";
    }
}
