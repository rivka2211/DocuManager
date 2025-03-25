using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManager.Core.Interfaces;
using DocuManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using File = DocuManager.Core.Entities.File;
using System.Data;

namespace DocuManager.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.Categories).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return await _context.Users
                .Where(u => !u.IsDeleted)
                .Include(u => u.Categories)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.Include(u => u.Categories).AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> AddUserAsync(User user)
        {
          return  _context.Users.Add(user).Entity;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            return  _context.Users.Update(user).Entity;
        }
        public async Task<bool> SoftDeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateUserRoleAsync(int userId, string role)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.Role = role;
                return true;
            }
            return false;
        }

        public async Task<User?> GetUserByNameAsync(string name)
        {
            return await _context.Users.Include(u => u.Categories).AsNoTracking().FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<User?> ValidateUserAsync(string name, string password)
        {
            return await _context.Users.Include(u => u.Categories).AsNoTracking().FirstOrDefaultAsync(u => u.Name == name && u.Password == password);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

