using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.HasKey(c => new { c.UserId, c.RoleId });

            builder.HasOne(ur => ur.Roles)
               .WithMany(r => r.UserRoles)
               .HasForeignKey(ur => ur.RoleId)
               .IsRequired();

                 builder.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

           

        }
    }
}
