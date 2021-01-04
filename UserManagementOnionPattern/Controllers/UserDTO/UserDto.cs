using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementOnionPattern.Controllers.UserDTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string Address { get; set; }

        public DateTime AddedDate { get; set; }
        public string IPAddress { get; set; }

       // public UserProfile userProfile { get; set; }
    }
}
