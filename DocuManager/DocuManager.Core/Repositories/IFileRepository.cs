using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManager.Core.DTOs;
using DocuManager.Core.Entities;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Data.Repositories.Interfaces
{
    public interface IFileRepository
    {
        Task SaveChangesAsync();

        Task<List<File>> GetAllFilesAsync();//admin
        //service only----Task<List<File>> GetAllActivityFilesAsync();//admin
        Task<bool> DeleteFileAsync(int id);
        //user
        Task<File> GetFileByIdAsync(int id);//
        Task<List<File>> GetAllUserFilesAsync(int userId);//with deleted
       // service only Task<List<File>> GetAllActivityUserFilesAsync(int userId);
        Task<List<File>> GetFilesByCategoryIdAsync(int categoryId);
        Task<File> AddFileAsync(int userId, File file);
        Task<File> UpdateFileAsync(int userId,int id, File file);
        Task<bool> SoftDeleteFileAsync(int userId, int id);
        Task<int>  DeleteUserFilesAsync(int id);
    }
}

