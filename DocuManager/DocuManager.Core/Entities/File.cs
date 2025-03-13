using System;
using System.Collections.Generic;
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

        public int UserId { get; set; }

        public Category Category { get; set; }

        public List<Category> Tags { get; set; }

        public File()
        {
            
        }

        public File(string fileName, string fileUrl, DateTime uploadTime, int userId, Category category, List<Category> tags)
        {
            FileName = fileName;
            FileUrl = fileUrl;
            UploadTime = uploadTime;
            UserId = userId;
            Category = category;
            Tags = tags;
        }
    }
}
