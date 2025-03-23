using DocuManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.DTOs
{
    public class FileDTO
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string FileUrl { get; set; }

        public DateTime UploadTime { get; set; }

        //public UserUpdateDTO User { get; set; }

        public int OwnerId { get; set; }

        public string Content { get; set; } = "";

        public int CategoryId { get; set; }

        public CategoryDTO Category { get; set; }

        public bool IsDeleted { get; set; }

        public FileDTO()
        {
            
        }
    }
    public class FileCreateDTO
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public int OwnerId { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; } 
    }
    public class FileUpdateDTO
    {
        public string FileName { get; set; }
        public int CategoryId { get; set; }
    }


}
