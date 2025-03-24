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
        //admin
        public async Task<List<File>> GetAllFilesAsync()
        {
            return await _context.Files.ToListAsync();
        }

        public async Task<bool> DeleteFileAsync(int id)
        {
            var file = await _context.Files.FindAsync(id);
            if (file == null) return false;

            _context.Files.Remove(file);
            await SaveChangesAsync();
            return true;
        }

        //user
        public async Task<File> GetFileByIdAsync(int id)
        {
            return await _context.Files.FindAsync(id);
        }

        public async Task<List<File>> GetAllUserFilesAsync(int userId)
        {
            return await _context.Files.Where(f => f.OwnerId == userId).ToListAsync();
        }

        public async Task<List<File>> GetFilesByCategoryIdAsync(int categoryId)
        {
            return await _context.Files
                .Where(f => f.CategoryId == categoryId).ToListAsync();
        }

        public async Task<File> AddFileAsync(int userId, File file)
        {
            var user = _context.Users.Where(u => u.Id == userId);
            var f= _context.Files.Add(file);
            await SaveChangesAsync();
            return f.Entity;
        }

        public async Task<File> UpdateFileAsync(int userId, int id, File file)
        {
            var f =await _context.Files.FindAsync(id);
            if (f != null && f.OwnerId == userId)
            {
                _context.Files.Update(file);
                await _context.SaveChangesAsync();
                 return file;
            }
            return default;
        }

        public async Task<bool> SoftDeleteFileAsync(int userId, int id)
        {
            var f = await GetFileByIdAsync(id);
            if (f != null && f.OwnerId == userId)
            {
                f.IsDeleted = false;
                _context.Files.Update(f);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<int> DeleteUserFilesAsync(int id)
        {
            var files=await _context.Files.Where(f => f.OwnerId == id && f.IsDeleted == false).ToListAsync();
            foreach (var file in files)
            {
                file.IsDeleted = false;
                _context.Files.Update(file);
            }
            await SaveChangesAsync();
            return files.Count;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}