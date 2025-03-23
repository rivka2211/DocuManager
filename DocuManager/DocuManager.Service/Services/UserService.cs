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
using DocuManager.Core.Repositories;
using DocuManager.Core.Services;
using DocuManager.Service.Interfaces;

namespace DocuManager.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileService _fileService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userService,IFileService fileRepository,ICategoryService categoryService, IMapper mapper)
        {
            _userRepository = userService;
            _fileService = fileRepository;
            _categoryService = categoryService;
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
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task AddUserAsync(UserDTO userDto)
        {
            var categoryDto = new CategoryDTO { Files = new List<FileDTO>(), Name = "שונות", Id = 0 };
            var category =await _categoryService.AddCategoryAsync(categoryDto);
            userDto.Categories.Add(category);
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(int id, UserUpdateDTO userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);
            user.Id = id;
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await SoftDeleteUserAsync(id);
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            await _fileService.DeleteUserFilesAsync(id);
            await _userRepository.SoftDeleteUserAsync(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAllActiveUsersAsync()
        {
            var users = await _userRepository.GetActiveUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task UpdateUserRoleAsync(int userId, string role)
        {
            await _userRepository.UpdateUserRoleAsync(userId, role);
        }

        public async Task<UserDTO?> GetUserByNameAsync(string name)
        {
            var user = await _userRepository.GetUserByNameAsync(name);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> ValidateUserAsync(string name, string password)
        {
            var user = await _userRepository.ValidateUserAsync(name, password);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }


    }
}


