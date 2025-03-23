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
        Task<List<FileDTO>> GetAllActivityFilesAsync();
        Task<FileDTO> GetFileByIdAsync(int id);
        Task<List<FileDTO>> GetFilesByUserIdAsync(int userId);
        Task<List<FileDTO>> GetFilesByCategoryIdAsync(int userId,int categoryId);
        Task<FileDTO> AddFileAsync(FileDTO fileDTO);
        Task<bool> DeleteFileAsync(int id);
        Task<bool> SoftDeleteFileAsync(int id);
        Task DeleteUserFilesAsync(int id);
    }
}

