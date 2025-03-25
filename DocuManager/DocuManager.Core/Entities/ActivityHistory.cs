using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.Entities
{
    public class ActivityHistory
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        public int? UserId { get; set; }

        public DateTime Timestamp { get; set; }

        public List<File> Files { get; set; }

        public ActivityHistory()
        {

        }
    }
}
