using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManager.Core.Entities;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Data.Repositories.Interfaces
{
    public interface IFileRepository
    {
        Task<List<File>> GetAllFilesAsync();
        Task<File> GetFileByIdAsync(int id);
        Task<List<File>> GetFilesByUserIdAsync(int userId);
        Task<List<File>> GetFilesByCategoryIdAsync(int categoryId);
        Task<File> AddFileAsync(File file);
        Task<bool> DeleteFileAsync(int id);
        Task<bool> DeleteUserFilesAsync(int id);
        Task SaveChangesAsync();
    }
}

