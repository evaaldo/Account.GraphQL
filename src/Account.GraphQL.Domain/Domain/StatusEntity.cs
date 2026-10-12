namespace Account.GraphQL.Domain.Domain
{
    public class StatusEntity
    {
        public string Status { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        public StatusEntity(string status, string description, bool isActive)
        {
            ValidateStatusValues(status, description);

            Status = status;
            Description = description;
            IsActive = isActive;
        }

        private void ValidateStatusValues(string status, string description)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Status cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.");
            }
        }
    }
}
