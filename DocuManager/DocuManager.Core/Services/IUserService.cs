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
        Task<IEnumerable<UserDTO>> GetAllActiveUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDTO userDto);
        Task UpdateUserAsync(int id, UserUpdateDTO userUpdateDto);
        Task DeleteUserAsync(int id);
        Task SoftDeleteUserAsync(int id);
        Task UpdateUserRoleAsync(int userId, string role);
        Task<UserDTO?> GetUserByNameAsync(string name);
        Task<UserDTO?> ValidateUserAsync(string name, string password);
   
    }
}

