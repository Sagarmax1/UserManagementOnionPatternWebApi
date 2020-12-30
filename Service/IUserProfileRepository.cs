using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IUserProfileRepository
    {
        UserProfile GetUserProfile(long Id);
    }
}
