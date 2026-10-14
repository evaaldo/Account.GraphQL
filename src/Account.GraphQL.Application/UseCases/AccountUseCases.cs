using Account.GraphQL.Api.DTOs.Request;
using Account.GraphQL.Application.DTOs.Request;
using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Application.Interfaces.UseCases;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.UseCases
{
    public class AccountUseCases : IAccountUseCases
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPersonUseCases _personUseCases;

        public AccountUseCases(IAccountRepository accountRepository, IPersonUseCases personUseCases)
        {
            _accountRepository = accountRepository;
            _personUseCases = personUseCases;
        }

        public async Task<IEnumerable<AccountResponseDto>> ListAccountsAsync()
        {
            return await _accountRepository.ListAccountsAsync();
        }

        public async Task<AccountResponseDto?> GetAccountByIdAsync(int id)
        {
            return await _accountRepository.GetAccountByIdAsync(id);
        }

        public async Task<int> CreateAccountAsync(AccountRequestDto accountRequest)
        {
            var personId = await _personUseCases.CreatePersonAsync(accountRequest.person);
            var accountEntity = new AccountEntity(personId, accountRequest.IdStatus);
            return await _accountRepository.CreateAccountAsync(accountEntity);
        }

        public async Task UpdateAccountByIdAsync(int id, AccountRequestDto accountRequest)
        {
            var existingAccount = await _accountRepository.GetAccountByIdAsync(id)
                ?? throw new Exception($"Account with ID {id} not found.");

            var accountEntity = new AccountEntity(existingAccount.IdPerson, accountRequest.IdStatus);
            await _accountRepository.UpdateAccountByIdAsync(id, accountEntity);
        }

        public async Task DeleteAccountByIdAsync(int id)
        {
            await _accountRepository.DeleteAccountByIdAsync(id);
        }
    }
}
