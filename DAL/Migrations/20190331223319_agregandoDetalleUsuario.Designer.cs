﻿// <auto-generated />
using System;
using DAL.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(TiendaDbContext))]
    [Migration("20190331223319_agregandoDetalleUsuario")]
    partial class agregandoDetalleUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Entities.Entities.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime?>("FechaModificacion");

                    b.Property<string>("Nombre");

                    b.Property<string>("Seudonimo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Entities.Entities.AutoresLibros", b =>
                {
                    b.Property<int>("IdAutor");

                    b.Property<int>("IdLibro");

                    b.HasKey("IdAutor", "IdLibro");

                    b.HasIndex("IdLibro");

                    b.ToTable("LibrosAutores");
                });

            modelBuilder.Entity("Entities.Entities.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime?>("FechaModificacion");

                    b.Property<string>("IdUsuario");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Entities.Entities.ComprasLibros", b =>
                {
                    b.Property<int>("IdCompra");

                    b.Property<int>("IdLibro");

                    b.Property<int>("Cantidad");

                    b.HasKey("IdCompra", "IdLibro");

                    b.HasIndex("IdLibro");

                    b.ToTable("ComprasLibros");
                });

            modelBuilder.Entity("Entities.Entities.DetalleUsuario", b =>
                {
                    b.Property<string>("Id");

                    b.Property<bool>("Premium");

                    b.HasKey("Id");

                    b.ToTable("DetallesUsuario");
                });

            modelBuilder.Entity("Entities.Entities.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime?>("FechaModificacion");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Entities.Entities.GenerosLibros", b =>
                {
                    b.Property<int>("IdGenero");

                    b.Property<int>("IdLibro");

                    b.HasKey("IdGenero", "IdLibro");

                    b.HasIndex("IdLibro");

                    b.ToTable("GenerosLibros");
                });

            modelBuilder.Entity("Entities.Entities.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime?>("FechaModificacion");

                    b.Property<DateTime>("FechaPublicacion");

                    b.Property<int>("Stock");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Entities.Entities.AutoresLibros", b =>
                {
                    b.HasOne("Entities.Entities.Autor", "Autor")
                        .WithMany("AutoresLibros")
                        .HasForeignKey("IdAutor")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Entities.Libro", "Libro")
                        .WithMany("AutoresLibros")
                        .HasForeignKey("IdLibro")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Entities.Compra", b =>
                {
                    b.HasOne("Entities.Entities.ApplicationUser", "Usuario")
                        .WithMany("Compras")
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("Entities.Entities.ComprasLibros", b =>
                {
                    b.HasOne("Entities.Entities.Compra", "Compra")
                        .WithMany("ComprasLibros")
                        .HasForeignKey("IdCompra")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Entities.Libro", "Libro")
                        .WithMany("ComprasLibros")
                        .HasForeignKey("IdLibro")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Entities.DetalleUsuario", b =>
                {
                    b.HasOne("Entities.Entities.ApplicationUser", "Usuario")
                        .WithOne("DetalleUsuario")
                        .HasForeignKey("Entities.Entities.DetalleUsuario", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Entities.GenerosLibros", b =>
                {
                    b.HasOne("Entities.Entities.Genero", "Genero")
                        .WithMany("GenerosLibros")
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Entities.Libro", "Libro")
                        .WithMany("GenerosLibros")
                        .HasForeignKey("IdLibro")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
