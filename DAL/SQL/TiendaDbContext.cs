using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQL
{
    public class TiendaDbContext : IdentityDbContext<ApplicationUser>
    {
        public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options)
        {

        }
    }
}
