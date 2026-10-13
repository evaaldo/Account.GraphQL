namespace Account.GraphQL.Api.GraphQL.Mutations
{
    public class AccountResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public StatusResult Status { get; set; } = new StatusResult();
    }
}
