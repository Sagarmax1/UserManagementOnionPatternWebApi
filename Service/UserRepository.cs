using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class UserRepository : IUserRepository
    {
        public void DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
