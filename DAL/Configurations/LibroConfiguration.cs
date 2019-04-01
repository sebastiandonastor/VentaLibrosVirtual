using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libros");

            builder.Property(l => l.FechaCreacion)
                .HasDefaultValue(DateTime.Now);

            builder.Property(l => l.Titulo)
                .IsRequired();

            builder.Property(l => l.Stock)
                .IsRequired();

            builder.HasKey(l => l.Id);
        }
    }
}
