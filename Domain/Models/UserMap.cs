using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Email).IsRequired();
            builder.Property(t => t.Password).IsRequired();

            builder.HasOne(t => t.userProfile).WithOne(u => u.user).HasForeignKey<UserProfile>(x => x.Id);
        }
    }
}
