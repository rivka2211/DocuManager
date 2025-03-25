using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int UserId { get; set; }

        // קשר One-to-Many - קטגוריה מכילה הרבה קבצים
        public List<File> Files { get; set; }

        public bool IsDeleted { get; set; }

    }

}
