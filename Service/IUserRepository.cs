using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(long Id);

        void InsertUser(User user);

        void UpdateUser(User user);

        void DeleteUser(long id);


    }
}
