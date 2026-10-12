using Account.GraphQL.Api.DTOs.Request;
using Account.GraphQL.Application.DTOs.Request;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.Interfaces.UseCases
{
    public interface IAccountUseCases
    {
        Task<IEnumerable<AccountEntity>> ListAccountsAsync();
        Task<AccountEntity?> GetAccountByIdAsync(int id);
        Task<int> CreateAccountAsync(AccountRequestDto accountRequest, PersonRequestDto personRequest);
        Task UpdateAccountByIdAsync(int id, AccountRequestDto accountRequest);
        Task DeleteAccountByIdAsync(int id);
    }
}
