using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class UserProfileMap
    {
        public UserProfileMap(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.FirstName).IsRequired();
            builder.Property(t => t.LastName).IsRequired();
            builder.Property(t => t.Address).IsRequired();

        }

    }
}
