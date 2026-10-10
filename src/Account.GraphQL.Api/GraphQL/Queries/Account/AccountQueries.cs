using Account.GraphQL.Api.GraphQL.Types;
using Bogus;
using HotChocolate;
using HotChocolate.Types;

namespace Account.GraphQL.Api.GraphQL.Queries.AccountQueries
{
    [ExtendObjectType(typeof(Query))]
    [GraphQLDescription("Provides queries related to account types.")]
    public class AccountQueries
    {
        private readonly Faker<AccountType> _accountFaker;

        public AccountQueries()
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
        }

        public IEnumerable<AccountType> GetAccounts()
        {
            return _accountFaker.Generate(10);
        }

        public AccountType GetAccountById(Guid id)
        {
            AccountType account = _accountFaker.Generate();
            account.Id = id;

            return account;
        }
    }
}
