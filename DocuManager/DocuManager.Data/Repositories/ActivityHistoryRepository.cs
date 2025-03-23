using DocuManager.Core.Entities;
using DocuManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Data.Repositories
{
    public class ActivityHistoryRepository : IActivityHistoryRepository
    {
        private readonly AppDbContext _context;

        public ActivityHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ActivityHistory>> GetUserHistoryAsync(int userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.History)
                .OrderByDescending(h => h.Timestamp)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ActivityHistory>> GetAllUsersHistoryAsync()
        {
            return await _context.Users
                .SelectMany(u => u.History)
                .OrderByDescending(h => h.Timestamp)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ActivityHistory>> GetActiveUsersHistoryAsync()
        {
            return await _context.Users
                .Where(u => !u.IsDeleted)
                .SelectMany(u => u.History)
                .OrderByDescending(h => h.Timestamp)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ActivityHistory>> GetUserHistoryByDateAsync(int userId, DateTime startDate, DateTime endDate)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.History)
                .Where(h => h.Timestamp >= startDate && h.Timestamp <= endDate)
                .OrderByDescending(h => h.Timestamp)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ActivityHistory>> GetAllUsersHistoryByDateAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Users
                .SelectMany(u => u.History)
                .Where(h => h.Timestamp >= startDate && h.Timestamp <= endDate)
                .OrderByDescending(h => h.Timestamp)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task AddHistoryRecordAsync(ActivityHistory history)
        {
            await _context.ActivityHistories.AddAsync(history);
            await _context.SaveChangesAsync();
        }
    }

}
