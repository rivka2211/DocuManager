using DocuManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IEnumerable<User>> GetActiveUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> SoftDeleteUserAsync(int id);
        Task<bool> UpdateUserRoleAsync(int userId, string role);
        Task<User?> GetUserByNameAsync(string name);
        Task<User?> ValidateUserAsync(string name, string password);
        Task SaveChangesAsync();
    }
}

