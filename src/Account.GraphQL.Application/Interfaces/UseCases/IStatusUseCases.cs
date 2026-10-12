using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.Interfaces.UseCases
{
    public interface IStatusUseCases
    {
        Task<IEnumerable<StatusEntity>> ListStatusesAsync();
        Task<StatusEntity?> GetStatusByIdAsync(int id);
        Task<int> CreateStatusAsync(StatusEntity status);
        Task UpdateStatusByIdAsync(int id, StatusEntity status);
        Task DeleteStatusByIdAsync(int id);
    }
}
