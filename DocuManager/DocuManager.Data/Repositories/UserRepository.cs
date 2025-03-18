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
            return await _context.Users.Include(u => u.Files).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.Include(u => u.Files).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserRoleAsync(int userId, string role)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.Role = role;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddFileToUserAsync(int userId, File file)
        {
            var user = await _context.Users.Include(u => u.Files).FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                user.Files.Add(file);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteFileFromUserAsync(int userId, int fileId)
        {
            var user = await _context.Users.Include(u => u.Files).FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                var file = user.Files.FirstOrDefault(f => f.Id == fileId);
                if (file != null)
                {
                    user.Files.Remove(file);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateFileNameAsync(int userId, int fileId, string name)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                var file = user.Files.FirstOrDefault(f => f.Id == fileId);
                if (file != null)
                {
                    file.FileName = name;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<User?> GetUserByNameAsync(string name)
        {
            return await _context.Users.Include(u => u.Files).FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<User?> ValidateUserAsync(string name, string password)
        {
            return await _context.Users.Include(u => u.Files).FirstOrDefaultAsync(u => u.Name == name&&u.Password==password);
            
        }
    }
}

