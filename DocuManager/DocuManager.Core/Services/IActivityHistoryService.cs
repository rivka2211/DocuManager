using DocuManager.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.Services
{
    public interface IActivityHistoryService
    {
        Task<List<ActivityHisotiryDTO>> GetUserHistoryAsync(int userId);
        Task<List<ActivityHisotiryDTO>> GetAllUsersHistoryAsync();
        Task<List<ActivityHisotiryDTO>> GetActiveUsersHistoryAsync();
        Task<List<ActivityHisotiryDTO>> GetUserHistoryByDateAsync(int userId, DateTime startDate, DateTime endDate);
        Task<List<ActivityHisotiryDTO>> GetAllUsersHistoryByDateAsync(DateTime startDate, DateTime endDate);
        Task<ActivityHisotiryDTO> CreateHistoryRecordAsync(ActivityHisotiryDTO historyDto);
    }
}
