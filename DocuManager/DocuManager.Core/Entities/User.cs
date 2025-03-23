using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public List<Category> Categories { get; set; }

        public List<ActivityHistory> History { get; set; }

        public bool IsDeleted { get; set; }

        public User()
        {

        }

        public User( string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
            Role = "user";
            //Files = new List<File>();
            Categories = new List<Category>();
            History = new List<ActivityHistory>();
        }
    }
   
}
