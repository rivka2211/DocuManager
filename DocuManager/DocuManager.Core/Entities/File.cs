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

        // קשר One-to-Many - כל קובץ שייך לקטגוריה אחת
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        //public List<Category> Tags { get; set; }

        // קשר Many-to-Many - (קובץ יכול להיות משויך למספר קטגוריות (תגיות
        public List<CategoryFile> CategoryFiles { get; set; }


        public File()
        {

        }


    }
}
