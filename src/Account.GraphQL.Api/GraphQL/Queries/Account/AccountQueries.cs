using Account.GraphQL.Application.DTOs.Response;
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

        public async Task<IEnumerable<AccountResponseDto>> GetAccounts()
        {
            return await _accountUseCases.ListAccountsAsync();
        }

        public async Task<AccountResponseDto> GetAccountById(int id)
        {
            return await _accountUseCases.GetAccountByIdAsync(id);
        }
    }
}
