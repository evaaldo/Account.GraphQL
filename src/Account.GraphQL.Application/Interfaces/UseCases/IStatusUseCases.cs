using Account.GraphQL.Application.DTOs.Request;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.Interfaces.UseCases
{
    public interface IStatusUseCases
    {
        Task<IEnumerable<StatusEntity>> ListStatusesAsync();
        Task<StatusEntity?> GetStatusByIdAsync(int id);
        Task<int> CreateStatusAsync(StatusRequestDto status);
        Task UpdateStatusByIdAsync(int id, StatusRequestDto status);
        Task DeleteStatusByIdAsync(int id);
    }
}
