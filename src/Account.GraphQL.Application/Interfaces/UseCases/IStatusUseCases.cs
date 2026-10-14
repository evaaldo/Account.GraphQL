using Account.GraphQL.Application.DTOs.Request;
using Account.GraphQL.Application.DTOs.Response;

namespace Account.GraphQL.Application.Interfaces.UseCases
{
    public interface IStatusUseCases
    {
        Task<IEnumerable<StatusResponseDto>> ListStatusesAsync();
        Task<StatusResponseDto?> GetStatusByIdAsync(int id);
        Task<int> CreateStatusAsync(StatusRequestDto status);
        Task UpdateStatusByIdAsync(int id, StatusRequestDto status);
        Task DeleteStatusByIdAsync(int id);
    }
}
