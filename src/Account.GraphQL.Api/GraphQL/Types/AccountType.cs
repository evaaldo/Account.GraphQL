namespace Account.GraphQL.Api.GraphQL.Types
{
    public class AccountType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public StatusType Status { get; set; } = new StatusType();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
