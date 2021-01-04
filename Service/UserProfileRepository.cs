using Domain.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class UserProfileRepository : IUserProfileRepository
    {
        IGenericRepository<User> userRepository;
        IGenericRepository<UserProfile> userProfileRepository;
        public UserProfileRepository(IGenericRepository<User> userRepository, IGenericRepository<UserProfile> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }
        public UserProfile GetUserProfile(long Id)
        {
            return userProfileRepository.Get(Id);
        }
    }
}
