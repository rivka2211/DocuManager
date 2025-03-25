using DocuManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.DTOs
{
    public class ActivityHisotiryDTO
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public DateTime Timestamp { get; set; }

        public List<FileUpdateDTO> Files { get; set; }
    }
}
