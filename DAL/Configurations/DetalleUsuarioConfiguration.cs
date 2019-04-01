using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    class DetalleUsuarioConfiguration : IEntityTypeConfiguration<DetalleUsuario>
    {
        public void Configure(EntityTypeBuilder<DetalleUsuario> builder)
        {
            builder.ToTable("DetallesUsuario");

            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.Usuario)
                .WithOne(d => d.DetalleUsuario)
                .HasForeignKey<DetalleUsuario>(d => d.Id);
        }
    }
}
