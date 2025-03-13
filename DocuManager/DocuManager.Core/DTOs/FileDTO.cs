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
        public int UserId { get; set; }
        public CategoryDTO Category { get; set; }
        public List<CategoryDTO> Tags { get; set; }
    }
    public class FileCreateDTO
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
    }


}
