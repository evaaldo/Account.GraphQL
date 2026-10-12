using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.Repository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<AccountEntity>> ListAccountsAsync();
        Task<AccountEntity?> GetAccountByIdAsync(int id);
        Task<int> CreateAccountAsync(AccountEntity account);
        Task UpdateAccountByIdAsync(int id, AccountEntity account);
        Task DeleteAccountByIdAsync(int id);
    }
}
