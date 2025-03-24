using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DocuManager.Core.DTOs;
using DocuManager.Core.Entities;
using DocuManager.Data.Repositories.Interfaces;
using DocuManager.Service.Interfaces;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Service.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public FileService(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<List<FileDTO>> GetAllFilesAsync()
        {
            var files = await _fileRepository.GetAllFilesAsync();
            return _mapper.Map<List<FileDTO>>(files);
        }

        public async Task<List<FileDTO>> GetAllActivityFilesAsync()
        {
            var files = await _fileRepository.GetAllFilesAsync();
            var activeFiles = files.Where(file => !file.IsDeleted);
            return _mapper.Map<List<FileDTO>>(activeFiles);
        }

        public async Task<bool> DeleteFileAsync(int id)
        {
            return await _fileRepository.DeleteFileAsync(id);
        }

        //user

        public async Task<FileDTO> GetFileByIdAsync(int id)
        {
            var file = await _fileRepository.GetFileByIdAsync(id);
            return file == null ? null : _mapper.Map<FileDTO>(file);
        }

        public async Task<List<FileDTO>> GetAllUserFilesAsync(int userId)
        {
            var files = await _fileRepository.GetAllUserFilesAsync(userId);
            return _mapper.Map<List<FileDTO>>(files);
        }

        public async Task<List<FileDTO>> GetAllActivityUserFilesAsync(int userId)
        {
            var files = await _fileRepository.GetAllUserFilesAsync(userId);
            var activeFiles = files.Where(file => !file.IsDeleted);
            return _mapper.Map<List<FileDTO>>(activeFiles);
        }

        public async Task<List<FileDTO>> GetFilesByCategoryIdAsync(int categoryId)
        {
            var files = await _fileRepository.GetFilesByCategoryIdAsync(categoryId);
            return _mapper.Map<List<FileDTO>>(files);
        }

        public async Task<FileDTO> AddFileAsync(int userId, FileCreateDTO fileDTO)
        {
            var file = new File(fileDTO);
            var addedFile = await _fileRepository.AddFileAsync(userId, file);
            return _mapper.Map<FileDTO>(addedFile);
        }

        public async Task<FileDTO> UpdateFileAsync(int userId, int id, FileUpdateDTO fileDTO)
        {
            var file = await _fileRepository.GetFileByIdAsync(id);
            if (file == null || file.OwnerId != userId)
                return null;
            file.FileName = fileDTO.FileName;
            file.CategoryId = fileDTO.CategoryId;
            file= await _fileRepository.UpdateFileAsync(userId, id, file);
            return _mapper.Map<FileDTO>(file);
        }

        public async Task<bool> SoftDeleteFileAsync(int userId, int id)
        {
            return await _fileRepository.SoftDeleteFileAsync(userId, id);
        }

        public async Task<int> DeleteUserFilesAsync(int id)
        {
          return await _fileRepository.DeleteUserFilesAsync(id);
        }
    }
}

