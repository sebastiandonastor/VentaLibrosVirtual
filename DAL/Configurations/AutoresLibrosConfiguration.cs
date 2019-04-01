using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class AutoresLibrosConfiguration : IEntityTypeConfiguration<AutoresLibros>
    {
        public void Configure(EntityTypeBuilder<AutoresLibros> builder)
        {

            builder.ToTable("LibrosAutores");

            builder.HasKey(a => new {a.IdAutor, a.IdLibro});

            builder.HasOne(a => a.Libro)
                .WithMany(l => l.AutoresLibros)
                .HasForeignKey(a => a.IdLibro);

            builder.HasOne(a => a.Autor)
                .WithMany(a => a.AutoresLibros)
                .HasForeignKey(a => a.IdAutor);
        }
    }
}
