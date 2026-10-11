using Account.GraphQL.Api.GraphQL.Types;
using HotChocolate;

namespace Account.GraphQL.Api.GraphQL.Mutations
{
    public class Mutation
    {
        private readonly List<AccountResult> _accounts;

        public Mutation()
        {
            _accounts = new List<AccountResult>();
        }

        public AccountResult CreateAccount(AccountInputType input)
        {
            AccountResult accountType = new AccountResult()
            {
                Id = Guid.NewGuid(),
                Name = input.AccountName,
                Number = input.AccountNumber,
                Status = new StatusResult()
                {
                    Id = input.StatusId,
                    Name = input.StatusName,
                    Description = input.StatusDescription,
                    IsActive = input.StatusIsActive
                }
            };

            _accounts.Add(accountType);

            return accountType;
        }

        public AccountResult UpdateAccount(Guid accountId, AccountInputType input)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == accountId);

            if (account == null)
            {
                throw new GraphQLException($"Account with ID {accountId} not found.");
            }

            account.Name = input.AccountName;
            account.Number = input.AccountNumber;
            account.Status.Id = input.StatusId;
            account.Status.Name = input.StatusName;
            account.Status.Description = input.StatusDescription;
            account.Status.IsActive = input.StatusIsActive;
            return account;
        }

        public bool DeleteAccount(Guid accountId)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == accountId);
            if (account == null)
            {
                throw new GraphQLException($"Account with ID {accountId} not found.");
            }
            _accounts.RemoveAll(a => a.Id == accountId);
            return true;
        }
    }
}
