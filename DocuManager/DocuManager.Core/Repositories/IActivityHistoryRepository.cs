using DocuManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.Repositories
{
    public interface IActivityHistoryRepository
    {
        Task<List<ActivityHistory>> GetUserHistoryAsync(int userId);
        Task<List<ActivityHistory>> GetAllUsersHistoryAsync();
        Task<List<ActivityHistory>> GetActiveUsersHistoryAsync();
        Task<List<ActivityHistory>> GetUserHistoryByDateAsync(int userId, DateTime startDate, DateTime endDate);
        Task<List<ActivityHistory>> GetAllUsersHistoryByDateAsync(DateTime startDate, DateTime endDate);
        Task AddHistoryRecordAsync(ActivityHistory history);
    }

}
