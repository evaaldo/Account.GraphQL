using Account.GraphQL.Api.DTOs.Request;
using Account.GraphQL.Application.DTOs.Request;
using Account.GraphQL.Application.DTOs.Response;

namespace Account.GraphQL.Application.Interfaces.UseCases
{
    public interface IAccountUseCases
    {
        Task<IEnumerable<AccountResponseDto>> ListAccountsAsync();
        Task<AccountResponseDto?> GetAccountByIdAsync(int id);
        Task<int> CreateAccountAsync(AccountRequestDto accountRequest);
        Task UpdateAccountByIdAsync(int id, AccountRequestDto accountRequest);
        Task DeleteAccountByIdAsync(int id);
    }
}
