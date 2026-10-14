using Account.GraphQL.Application.DTOs.Request;
using Account.GraphQL.Application.DTOs.Response;
using Account.GraphQL.Application.Interfaces.Repository;
using Account.GraphQL.Application.Interfaces.UseCases;
using Account.GraphQL.Domain.Domain;

namespace Account.GraphQL.Application.UseCases
{
    public class StatusUseCases : IStatusUseCases
    {
        private readonly IStatusRepository _statusRepository;

        public StatusUseCases(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<IEnumerable<StatusResponseDto>> ListStatusesAsync()
        {;
            return await _statusRepository.ListStatusesAsync();
        }

        public async Task<StatusResponseDto?> GetStatusByIdAsync(int id)
        {
            return await _statusRepository.GetStatusByIdAsync(id);
        }

        public async Task<int> CreateStatusAsync(StatusRequestDto status)
        {
            var statusEntity = new StatusEntity(status.Status, status.Description, status.IsActive);
            return await _statusRepository.CreateStatusAsync(statusEntity);
        }

        public async Task UpdateStatusByIdAsync(int id, StatusRequestDto status)
        {
            var statusEntity = new StatusEntity(status.Status, status.Description, status.IsActive);
            await _statusRepository.UpdateStatusByIdAsync(id, statusEntity);
        }

        public async Task DeleteStatusByIdAsync(int id)
        {
            await _statusRepository.DeleteStatusByIdAsync(id);
        }
    }
}
