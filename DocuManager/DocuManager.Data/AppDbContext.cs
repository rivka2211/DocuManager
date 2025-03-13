using DocuManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
    }
}