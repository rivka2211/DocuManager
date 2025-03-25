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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userService,IFileService fileRepository,ICategoryRepository categoryService, IMapper mapper)
        {
            _userRepository = userService;
            _fileService = fileRepository;
            _categoryRepository = categoryService;
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

        public async Task<UserDTO> AddUserAsync(UserUpdateDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user=  await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
            var category = new Category {Id = 0, Name = "שונות",UserId=user.Id,User=user, Files = new List<File>(),IsDeleted=false };
            category = await _categoryRepository.AddCategoryAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UserUpdateDTO userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);
            user.Id = id;
            user= await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            await _fileService.DeleteUserFilesAsync(id);
            var good= await _userRepository.DeleteUserAsync(id);
            await _userRepository.SaveChangesAsync();
            return good;
        }

        public async Task<bool> SoftDeleteUserAsync(int id)
        {
            await _fileService.DeleteUserFilesAsync(id);
           var good= await _userRepository.SoftDeleteUserAsync(id);
            await _userRepository.SaveChangesAsync();
            return good;
        }

        public async Task<IEnumerable<UserDTO>> GetAllActiveUsersAsync()
        {
            var users = await _userRepository.GetActiveUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<bool> UpdateUserRoleAsync(int userId, string role)
        {
          var s= await _userRepository.UpdateUserRoleAsync(userId, role);
            await _userRepository.SaveChangesAsync();
            return s;
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


