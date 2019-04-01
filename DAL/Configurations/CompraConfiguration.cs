using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class CompraConfiguration : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compras");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Usuario)
                .WithMany(u => u.Compras)
                .HasForeignKey(c => c.IdUsuario);

            
        }
    }
}
