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
        Task<UserDTO> AddUserAsync(UserUpdateDTO userDto);
        Task<UserDTO> UpdateUserAsync(int id, UserUpdateDTO userUpdateDto);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> SoftDeleteUserAsync(int id);
        Task<bool> UpdateUserRoleAsync(int userId, string role);
        Task<UserDTO?> GetUserByNameAsync(string name);
        Task<UserDTO?> ValidateUserAsync(string name, string password);
   
    }
}

