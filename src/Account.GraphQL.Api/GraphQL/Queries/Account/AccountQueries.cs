using Account.GraphQL.Application.Interfaces.UseCases;
using HotChocolate;
using HotChocolate.Types;

namespace Account.GraphQL.Api.GraphQL.Queries.AccountQueries
{
    [ExtendObjectType(typeof(Query))]
    [GraphQLDescription("Provides queries related to account types.")]
    public class AccountQueries
    {
        private readonly IAccountUseCases _accountUseCases;

        public AccountQueries(IAccountUseCases accountUseCases)
        {
            _accountUseCases = accountUseCases;
        }

        public void GetAccounts()
        {
            throw new NotImplementedException();
        }

        public void GetAccountById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
