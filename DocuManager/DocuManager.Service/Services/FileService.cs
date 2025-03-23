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

        public async Task<FileDTO> GetFileByIdAsync(int id)
        {
            var file = await _fileRepository.GetFileByIdAsync(id);
            return file == null ? null : _mapper.Map<FileDTO>(file);
        }

        public async Task<List<FileDTO>> GetFilesByUserIdAsync(int userId)
        {
            var files = await _fileRepository.GetFilesByUserIdAsync(userId);
            return _mapper.Map<List<FileDTO>>(files);
        }

        public async Task<List<FileDTO>> GetFilesByCategoryIdAsync(int categoryId)
        {
            var files = await _fileRepository.GetFilesByCategoryIdAsync(categoryId);
            return _mapper.Map<List<FileDTO>>(files);
        }

        public async Task<FileDTO> AddFileAsync(FileDTO fileDTO)
        {
            var file = _mapper.Map<File>(fileDTO);
            file.UploadTime = DateTime.UtcNow;

            var addedFile = await _fileRepository.AddFileAsync(file);
            return _mapper.Map<FileDTO>(addedFile);
        }

        public async Task<bool> DeleteFileAsync(int id)
        {
            return await _fileRepository.DeleteFileAsync(id);
        }

        public async Task DeleteUserFilesAsync(int id)
        {
             await _fileRepository.DeleteUserFilesAsync(id);
        }
    }
}

