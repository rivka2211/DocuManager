using DocuManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        //public List<FileDTO> Files { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class UserUpdateDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


    }
    public class UserHistoryDTO
    {
        public string Name { get; set; }
        public List<ActivityHistory> History { get; set; }

    }

}
