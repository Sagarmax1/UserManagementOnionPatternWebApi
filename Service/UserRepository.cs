using Domain.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class UserRepository : IUserRepository
    {
        IGenericRepository<User> userRepository;

        IGenericRepository<UserProfile> userProfileRepository;

        public UserRepository(IGenericRepository<User> userRepository, IGenericRepository<UserProfile> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }

        public void DeleteUser(long id)
        {
            UserProfile userprofile = userProfileRepository.Get(id);

            userProfileRepository.Remove(userprofile);

            User user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }

        public User GetUser(long Id)
        {
            return this.userRepository.Get(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.update(user);
        }
    }
}
