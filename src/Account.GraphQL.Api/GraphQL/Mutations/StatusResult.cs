namespace Account.GraphQL.Api.GraphQL.Mutations
{
    public class StatusResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public bool IsActive { get; set; }
    }
}
