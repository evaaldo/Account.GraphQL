using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.Interfaces.Repository
{
    public interface IStatusRepository
    {
        Task<IEnumerable<StatusResponseDto>> ListStatusesAsync();
        Task<StatusResponseDto?> GetStatusByIdAsync(int id);
        Task<int> CreateStatusAsync(StatusEntity status);
        Task UpdateStatusByIdAsync(int id, StatusEntity status);
        Task DeleteStatusByIdAsync(int id);
    }
}
