using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManager.Core.DTOs;

namespace DocuManager.Service.Interfaces
{
    public interface IFileService
    {
        Task<List<FileDTO>> GetAllFilesAsync();
        Task<FileDTO> GetFileByIdAsync(int id);
        Task<List<FileDTO>> GetFilesByUserIdAsync(int userId);
        Task<List<FileDTO>> GetFilesByCategoryIdAsync(int categoryId);
        Task<List<FileDTO>> GetFilesByTagsAsync(List<int> tagIds);
        Task<FileDTO> AddFileAsync(FileDTO fileDTO);
        Task<bool> DeleteFileAsync(int id);
    }
}

