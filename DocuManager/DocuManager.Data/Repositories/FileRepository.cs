using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManager.Core.Entities;
using DocuManager.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext _context;

        public FileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<File>> GetAllFilesAsync()
        {
            return await _context.Files.ToListAsync();
        }

        public async Task<File> GetFileByIdAsync(int id)
        {
            return await _context.Files.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<File>> GetFilesByUserIdAsync(int userId)
        {
            return await _context.Files.Where(f => f.OwnerId == userId).ToListAsync();
        }

        public async Task<List<File>> GetFilesByCategoryIdAsync(int categoryId)
        {
            return await _context.Files
                .Where(f => f.CategoryId == categoryId).ToListAsync();
        }

        public async Task<File> AddFileAsync(File file)
        {
            _context.Files.Add(file);
            await SaveChangesAsync();
            return file;
        }

        public async Task<bool> DeleteFileAsync(int id)
        {
            var file = await _context.Files.FirstOrDefaultAsync(f => f.Id == id);
            if (file == null) return false;

            _context.Files.Remove(file);
            await SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUserFilesAsync(int id)
        {
            _context.Files.Where(f => f.OwnerId == id && f.IsDeleted == false)
                .ExecuteUpdateAsync(setters => setters.SetProperty(f => f.IsDeleted, true));
            await SaveChangesAsync();
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}