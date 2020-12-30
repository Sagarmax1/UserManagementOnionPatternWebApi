using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.EntityFrameWorkCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Linking (user---usermap,userprofile---userprofilema)

            new UserMap(builder.Entity<User>());
            new UserProfileMap(builder.Entity<UserProfile>());
        }
    }
}
