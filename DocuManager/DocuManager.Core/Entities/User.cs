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

        public List<File> Files { get;  set; }

        public List<Category> Categories { get; set; }

        public User()
        {
            
        }

        public User(int id,string name, string password, string email)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Role = "user";
            Files = new List<File>();
        }
    }
}
