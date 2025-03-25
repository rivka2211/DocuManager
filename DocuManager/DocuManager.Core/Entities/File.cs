using DocuManager.Core.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.Entities
{
    public class File
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string FileUrl { get; set; }

        public DateTime UploadTime { get; set; }

        public  int OwnerId { get; set; }

        public string Content { get; set; } = "";

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }

        public List<ActivityHistory> ActivityHistories { get; set; }


        public bool IsDeleted { get; set; }


        public File()
        {

        }

        public File(string fileName, string fileUrl, int userId, int categoryId)
        {
            FileName = fileName;
            FileUrl = fileUrl;
            OwnerId = userId;
            UploadTime = DateTime.UtcNow;
            CategoryId = categoryId;
        }

        public File(FileCreateDTO dto)
        {
            FileName = dto.FileName;
            FileUrl = dto.FileUrl;
            OwnerId = dto.OwnerId;
            CategoryId = dto.CategoryId;
            IsDeleted = false; // תמיד שלילי ביצירה
            UploadTime = DateTime.UtcNow; // יכול להיות שימושי להגדיר מיידית
        }
    }
}
