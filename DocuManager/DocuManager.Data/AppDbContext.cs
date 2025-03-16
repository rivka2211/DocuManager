using DocuManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryFile> CategoryFiles { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // קשר One-to-Many בין File ל-Category
            modelBuilder.Entity<File>()
                .HasOne(f => f.Category)
                .WithMany(c => c.Files)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // או Cascade בהתאם לצורך

            // קשר Many-to-Many בין File ל-Category
            modelBuilder.Entity<CategoryFile>()
                .HasKey(cf => new { cf.FileId, cf.CategoryId });

            modelBuilder.Entity<CategoryFile>()
                .HasOne(cf => cf.File)
                .WithMany(f => f.CategoryFiles)
                .HasForeignKey(cf => cf.FileId);

            modelBuilder.Entity<CategoryFile>()
                .HasOne(cf => cf.Category)
                .WithMany(c => c.CategoryFiles)
                .HasForeignKey(cf => cf.CategoryId);

            modelBuilder.Entity<User>()
                 .Property(u => u.Role)
                 .HasDefaultValue("USER");
        }

    }
}