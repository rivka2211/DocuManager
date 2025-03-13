using DocuManager.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddUserAsync(UserUpdateDto userDto);
        Task UpdateUserAsync(int id, UserUpdateDto userDto);
        Task DeleteUserAsync(int id);
        Task UpdateUserRoleAsync(int userId, string role);
        Task AddFileToUserAsync(int userId, File file);
        Task DeleteFileFromUserAsync(int userId, int fileId);
    }
}

