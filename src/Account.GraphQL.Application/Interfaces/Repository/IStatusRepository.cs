using Account.GraphQL.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.GraphQL.Application.Interfaces.Repository
{
    public interface IStatusRepository
    {
        Task<IEnumerable<StatusEntity>> ListStatusesAsync();
        Task<StatusEntity?> GetStatusByIdAsync(int id);
        Task<int> CreateStatusAsync(StatusEntity status);
        Task UpdateStatusByIdAsync(int id, StatusEntity status);
        Task DeleteStatusByIdAsync(int id);
    }
}
