namespace Account.GraphQL.Application.DTOs.Request
{
    public class StatusRequestDto
    {
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
