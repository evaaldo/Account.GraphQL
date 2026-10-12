using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Application.Interfaces.UseCases;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.UseCases
{
    public class AccountUseCases : IAccountUseCases
    {
        private readonly IAccountRepository _accountRepository;

        public AccountUseCases(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<IEnumerable<AccountEntity>> ListAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccountEntity?> GetAccountByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAccountAsync(AccountEntity account)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccountByIdAsync(int id, AccountEntity account)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccountByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
