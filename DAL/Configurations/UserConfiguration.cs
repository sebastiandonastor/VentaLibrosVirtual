using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

              public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
       
         
        }
    }
}
