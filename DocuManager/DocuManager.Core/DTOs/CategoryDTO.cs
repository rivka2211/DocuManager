using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FileDTO> Files { get; set; }

    }
}
