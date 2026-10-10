using Account.GraphQL.Api.GraphQL.Types;
using Bogus;
using HotChocolate;
using HotChocolate.Types;

namespace Account.GraphQL.Api.GraphQL.Queries.Status
{
    [ExtendObjectType(typeof(Query))]
    [GraphQLDescription("Provides queries related to status types.")]
    public class StatusQueries
    {
        private readonly Faker<StatusType> _statusFaker;

        public StatusQueries()
        {
            _statusFaker = new Faker<StatusType>()
                .RuleFor(s => s.Id, f => f.Random.Guid())
                .RuleFor(s => s.Name, f => f.Lorem.Word())
                .RuleFor(s => s.Description, f => f.Lorem.Sentence())
                .RuleFor(s => s.IsActive, f => f.Random.Bool())
                .RuleFor(s => s.CreatedAt, f => f.Date.Past())
                .RuleFor(s => s.UpdatedAt, f => f.Date.Past());
        }

        public IEnumerable<StatusType> GetStatus()
        {
            return _statusFaker.Generate(5);
        }
    }
}
