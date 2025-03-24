using DocuManager.Core.DTOs;
using DocuManager.Core.Entities;
using DocuManager.Core.Repositories;
using DocuManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Service.Services
{
    public class ActivityHistoryService : IActivityHistoryService
    {
        private readonly IActivityHistoryRepository _historyRepository;

        public ActivityHistoryService(IActivityHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<List<ActivityHisotiryDTO>> GetUserHistoryAsync(int userId)
        {
            var history = await _historyRepository.GetUserHistoryAsync(userId);
            return history.Select(h => new ActivityHisotiryDTO
            {
                Id = h.Id,
                UserId = h.UserId,
                Timestamp = h.Timestamp,
                Files = h.Files.Select(f => new FileUpdateDTO { FileName = f.FileName, CategoryId = f.CategoryId }).ToList()
            }).ToList();
        }

        public async Task<List<ActivityHisotiryDTO>> GetAllUsersHistoryAsync()
        {
            var history = await _historyRepository.GetAllUsersHistoryAsync();
            return history.Select(h => new ActivityHisotiryDTO
            {
                Id = h.Id,
                UserId = h.UserId,
                Timestamp = h.Timestamp,
                Files = h.Files.Select(f => new FileUpdateDTO { FileName = f.FileName, CategoryId = f.CategoryId }).ToList()
            }).ToList();
        }

        public async Task<List<ActivityHisotiryDTO>> GetActiveUsersHistoryAsync()
        {
            var history = await _historyRepository.GetActiveUsersHistoryAsync();
            return history.Select(h => new ActivityHisotiryDTO
            {
                Id = h.Id,
                UserId = h.UserId,
                Timestamp = h.Timestamp,
                Files = h.Files.Select(f => new FileUpdateDTO { FileName = f.FileName, CategoryId = f.CategoryId }).ToList()
            }).ToList();
        }

        public async Task<List<ActivityHisotiryDTO>> GetUserHistoryByDateAsync(int userId, DateTime startDate, DateTime endDate)
        {
            var history = await _historyRepository.GetUserHistoryByDateAsync(userId, startDate, endDate);
            return history.Select(h => new ActivityHisotiryDTO
            {
                Id = h.Id,
                UserId = h.UserId,
                Timestamp = h.Timestamp,
                Files = h.Files.Select(f => new FileUpdateDTO { FileName = f.FileName, CategoryId = f.CategoryId }).ToList()
            }).ToList();
        }

        public async Task<List<ActivityHisotiryDTO>> GetAllUsersHistoryByDateAsync(DateTime startDate, DateTime endDate)
        {
            var history = await _historyRepository.GetAllUsersHistoryByDateAsync(startDate, endDate);
            return history.Select(h => new ActivityHisotiryDTO
            {
                Id = h.Id,
                UserId = h.UserId,
                Timestamp = h.Timestamp,
                Files = h.Files.Select(f => new FileUpdateDTO { FileName = f.FileName, CategoryId = f.CategoryId }).ToList()
            }).ToList();
        }

        public async Task<ActivityHisotiryDTO> CreateHistoryRecordAsync(ActivityHisotiryDTO historyDto)
        {
            var history = new ActivityHistory
            {
                UserId = historyDto.UserId,
                Timestamp = historyDto.Timestamp,
                Files = historyDto.Files.Select(f => new File { FileName = f.FileName, CategoryId = f.CategoryId }).ToList()
            };

            await _historyRepository.AddHistoryRecordAsync(history);
            return historyDto;
        }
    }
}
