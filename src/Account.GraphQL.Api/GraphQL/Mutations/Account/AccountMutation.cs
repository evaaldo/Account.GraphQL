using Account.GraphQL.Api.DTOs.Request;
using Account.GraphQL.Application.DTOs.Request;
using Account.GraphQL.Application.Interfaces.UseCases;
using HotChocolate;
using HotChocolate.Types;

namespace Account.GraphQL.Api.GraphQL.Mutations.Account
{
    [ExtendObjectType(typeof(Mutation))]
    [GraphQLDescription("Provides mutations related to account types.")]
    public class AccountMutation
    {
        private readonly IAccountUseCases _accountUseCase;

        public AccountMutation(IAccountUseCases accountUseCase)
        {
            _accountUseCase = accountUseCase;
        }

        public async Task<int> CreateAccount(AccountRequestDto account, PersonRequestDto person)
        {
            return await _accountUseCase.CreateAccountAsync(account, person);
        }

        public async Task UpdateAccountById(int id, AccountRequestDto account)
        {
            await _accountUseCase.UpdateAccountByIdAsync(id, account);
        }

        public async Task DeleteAccountById(int id)
        {
            await _accountUseCase.DeleteAccountByIdAsync(id);
        }
    }
}
