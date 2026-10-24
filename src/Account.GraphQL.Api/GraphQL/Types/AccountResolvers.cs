using Account.GraphQL.Api.GraphQL.DataLoaders;
using Account.GraphQL.Application.DTOs.Response;
using HotChocolate;
using HotChocolate.Types;

namespace Account.GraphQL.Api.GraphQL.Types
{
    [ExtendObjectType(typeof(AccountResponseDto))]
    public class AccountResolvers
    {
        public Task<PersonResponseDto?> GetPerson([Parent] AccountResponseDto account, PersonByIdDataLoader loader, CancellationToken cancellationToken)
        {
            return loader.LoadAsync(account.IdPerson, cancellationToken);
        }

        public Task<StatusResponseDto?> GetStatus([Parent] AccountResponseDto account, StatusByIdDataLoader loader, CancellationToken cancellationToken)
        {
            return loader.LoadAsync(account.IdStatus, cancellationToken);
        }
    }
}
