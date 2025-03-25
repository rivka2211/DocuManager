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
        public DbSet<ActivityHistory> ActivityHistories { get; set; }

       

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<File>()
                .HasOne<Category>(f => f.Category)
                .WithMany(c => c.Files)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<File>()
                 .HasOne<User>()
                 .WithMany()
                 .HasForeignKey(f => f.OwnerId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ActivityHistory>()
                .HasOne(ah => ah.User)
                .WithMany(u => u.History)
                .HasForeignKey(ah => ah.UserId)
                .OnDelete(DeleteBehavior.SetNull); // ההיסטוריה לא נמחקת עם המשתמש

            //modelBuilder.Entity<ActivityHistory>()
            //    .HasMany(ah => ah.Files)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.SetNull); // אם ההיסטוריה נמחקת, רק מסירים את הקישור מהקובץ

            // 🔹 הוספת אינדקסים לשיפור ביצועים
            modelBuilder.Entity<File>()
                .HasIndex(f => f.OwnerId);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.UserId);

            modelBuilder.Entity<ActivityHistory>()
                .HasIndex(ah => ah.UserId);
        }
    }
}