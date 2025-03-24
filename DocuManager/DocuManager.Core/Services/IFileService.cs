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
        Task<List<FileDTO>> GetAllFilesAsync();//admin
        Task<List<FileDTO>> GetAllActivityFilesAsync();//admin
        Task<bool> DeleteFileAsync( int id);
        //user
        Task<FileDTO> GetFileByIdAsync(int id);
        Task<List<FileDTO>> GetAllUserFilesAsync(int userId);//with deleted
        Task<List<FileDTO>> GetAllActivityUserFilesAsync(int userId);
        Task<List<FileDTO>> GetFilesByCategoryIdAsync(int categoryId);
        Task<FileDTO> AddFileAsync(int userId, FileCreateDTO fileDTO);
        Task<FileDTO> UpdateFileAsync(int userId, int id, FileUpdateDTO fileDTO);
        Task<bool> SoftDeleteFileAsync(int userId, int id);
        Task<int> DeleteUserFilesAsync(int id);
    }
}

