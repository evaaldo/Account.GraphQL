using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.Interfaces.Repository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<AccountResponseDto>> ListAccountsAsync();
        Task<AccountResponseDto?> GetAccountByIdAsync(int id);
        Task<int> CreateAccountAsync(AccountEntity account);
        Task UpdateAccountByIdAsync(int id, AccountEntity account);
        Task DeleteAccountByIdAsync(int id);
    }
}
