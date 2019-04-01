using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class GenerosLibrosConfiguration : IEntityTypeConfiguration<GenerosLibros>
    {
        public void Configure(EntityTypeBuilder<GenerosLibros> builder)
        {
            builder.ToTable("GenerosLibros");

            builder.HasKey(g => new { g.IdGenero, g.IdLibro });

            builder.HasOne(g => g.Libro)
                .WithMany(l => l.GenerosLibros)
                .HasForeignKey(g => g.IdLibro);

            builder.HasOne(g => g.Genero)
                .WithMany(g => g.GenerosLibros)
                .HasForeignKey(g => g.IdGenero);
        }
    }
}
