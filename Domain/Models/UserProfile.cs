using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class UserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public User user { get; set; }  //Navigation Properties

    }
}
