using DAL.Configurations;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQL
{
    public class TiendaDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
    ApplicationUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AutorConfiguration());
            builder.ApplyConfiguration(new LibroConfiguration());
            builder.ApplyConfiguration(new AutoresLibrosConfiguration());
            builder.ApplyConfiguration(new GeneroConfiguration());
            builder.ApplyConfiguration(new GenerosLibrosConfiguration());
            builder.ApplyConfiguration(new CompraConfiguration());
            builder.ApplyConfiguration(new CompraLibroConfiguration());
            builder.ApplyConfiguration(new DetalleUsuarioConfiguration());
            builder.ApplyConfiguration(new UserRolesConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            
        }


        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<AutoresLibros> AutoresLibros { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<GenerosLibros> GenerosLibros { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ComprasLibros> ComprasLibros { get; set; }
        public DbSet<DetalleUsuario> DetallesUsuario { get; set; }

    }
}
