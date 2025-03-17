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
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task UpdateUserRoleAsync(int userId, string role);
        Task AddFileToUserAsync(int userId, File file);
        Task DeleteFileFromUserAsync(int userId, int fileId);
        Task UpdateFileNameAsync(int userId, int fileId, string name);
    }
}

