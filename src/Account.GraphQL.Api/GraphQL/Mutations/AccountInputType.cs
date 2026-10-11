namespace Account.GraphQL.Api.GraphQL.Mutations
{
    public class AccountInputType
    {
        public string AccountName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public Guid StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;
        public bool StatusIsActive { get; set; }
    }
}
