using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocuManager.Core.Interfaces;
using DocuManager.Core.Entities;
using AutoMapper;
using DocuManager.Core.DTOs;
using File = DocuManager.Core.Entities.File;
using DocuManager.Data.Repositories.Interfaces;

namespace DocuManager.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task AddUserAsync(UserUpdateDto UserDTO)
        {
            var user = _mapper.Map<User>(UserDTO);
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(int id, UserUpdateDto UserDTO)
        {
            var user = _mapper.Map<User>(UserDTO);
            user.Id = id;
            await _userRepository.UpdateUserAsync(user);
        }
        public async Task UpdateUserRoleAsync(int userId, string role)
        {
            await _userRepository.UpdateUserRoleAsync(userId, role);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task AddFileToUserAsync(int userId, File file)
        {
            await _userRepository.AddFileToUserAsync(userId, file);
        }

        public async Task DeleteFileFromUserAsync(int userId, int fileId)
        {
            await _userRepository.DeleteFileFromUserAsync(userId, fileId);
        }

        public async Task UpdateFileNameAsync(int userId, int fileId, string name)
        {
            await _userRepository.UpdateFileNameAsync(userId, fileId, name);
        }

        public async Task<UserDTO?> GetUserByNameAsync(string name)
        {
            var user = await _userRepository.GetUserByNameAsync(name);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> ValidateUserAsync(string name, string password)
        {
            var user = await _userRepository.ValidateUserAsync(name, password);
            return _mapper.Map<UserDTO>(user);
        }
    }
}


