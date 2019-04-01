using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class CompraLibroConfiguration : IEntityTypeConfiguration<ComprasLibros>
    {
        public void Configure(EntityTypeBuilder<ComprasLibros> builder)
        {
            builder.ToTable("ComprasLibros");

            builder.HasKey(c => new { c.IdCompra,c.IdLibro });

            builder.HasOne(c => c.Compra)
                .WithMany(c => c.ComprasLibros)
                .HasForeignKey(c => c.IdCompra);

            builder.HasOne(c => c.Libro)
                .WithMany(c => c.ComprasLibros)
                .HasForeignKey(c => c.IdLibro);

        }
    }
}
