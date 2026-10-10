using HotChocolate;
using Bogus;

namespace Account.GraphQL.Api.GraphQL.Schemas
{
    public class Query
    {

        private readonly Faker<AccountType> _accountFaker;
        private readonly Faker<StatusType> _statusFaker;

        public Query()
        {
            _accountFaker = new Faker<AccountType>()
                .RuleFor(a => a.Id, f => f.Random.Guid())
                .RuleFor(a => a.Name, f => f.Company.CompanyName())
                .RuleFor(a => a.Number, f => f.Finance.Account())
                .RuleFor(a => a.Status, f => new StatusType
                {
                    Id = f.Random.Guid(),
                    Name = f.Lorem.Word(),
                    Description = f.Lorem.Sentence(),
                    IsActive = f.Random.Bool(),
                    CreatedAt = f.Date.Past(),
                    UpdatedAt = f.Date.Past()
                })
                .RuleFor(a => a.CreatedAt, f => f.Date.Past())
                .RuleFor(a => a.UpdatedAt, f => f.Date.Past());

            _statusFaker = new Faker<StatusType>()
                .RuleFor(s => s.Id, f => f.Random.Guid())
                .RuleFor(s => s.Name, f => f.Lorem.Word())
                .RuleFor(s => s.Description, f => f.Lorem.Sentence())
                .RuleFor(s => s.IsActive, f => f.Random.Bool())
                .RuleFor(s => s.CreatedAt, f => f.Date.Past())
                .RuleFor(s => s.UpdatedAt, f => f.Date.Past());
        }

        public IEnumerable<AccountType> GetAccounts()
        {
            return _accountFaker.Generate(10);
        }

        public IEnumerable<StatusType> GetStatus()
        {
            return _statusFaker.Generate(5);
        }

        public AccountType GetAccountById(Guid id)
        {
            AccountType account = _accountFaker.Generate();
            account.Id = id;

            return account;
        }

        [GraphQLDeprecated("This query is deprecated")]
        public string Instructions => "Arrocha esse GraphQL";
    }
}
