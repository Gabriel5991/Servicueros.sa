﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ServicuerosSA.Data;
using System;

namespace ServicuerosSA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd();

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
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("ServicuerosSA.Models.ApplicationUser", b =>
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

            modelBuilder.Entity("ServicuerosSA.Models.Bodega", b =>
                {
                    b.Property<int>("BodegaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CantidadAlmacenamiento");

                    b.Property<string>("NombreBodega")
                        .IsRequired();

                    b.Property<int>("NumeroEstantes");

                    b.Property<int>("TipoBodegaId");

                    b.Property<string>("Ubicacion")
                        .IsRequired();

                    b.HasKey("BodegaId");

                    b.HasIndex("TipoBodegaId");

                    b.ToTable("Bodega");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Bodega1", b =>
                {
                    b.Property<int>("Bodega1Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BodegaId");

                    b.Property<int>("ClasificacionId");

                    b.Property<DateTime>("Fechaingreso");

                    b.Property<int>("LoteId");

                    b.Property<int>("NumeroEstanteria");

                    b.Property<string>("Observaciones");

                    b.Property<int>("Peso");

                    b.HasKey("Bodega1Id");

                    b.HasIndex("BodegaId");

                    b.HasIndex("ClasificacionId");

                    b.HasIndex("LoteId");

                    b.ToTable("Bodega1");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Clasificacion", b =>
                {
                    b.Property<int>("ClasificacionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Selecciones")
                        .IsRequired();

                    b.HasKey("ClasificacionId");

                    b.ToTable("Clasificacion");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Lote", b =>
                {
                    b.Property<int>("LoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigolote")
                        .IsRequired();

                    b.Property<DateTime>("Fechaingreso");

                    b.Property<int>("Numerodepieles");

                    b.Property<string>("Observaciones");

                    b.Property<int>("PersonalId");

                    b.Property<int>("TipoPielId");

                    b.HasKey("LoteId");

                    b.HasIndex("PersonalId");

                    b.HasIndex("TipoPielId");

                    b.ToTable("Lote");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Personal", b =>
                {
                    b.Property<int>("PersonalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos")
                        .IsRequired();

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.Property<string>("Direccion");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("Nombres")
                        .IsRequired();

                    b.Property<int>("SexoId");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.HasKey("PersonalId");

                    b.HasIndex("SexoId");

                    b.ToTable("Personal");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Proveedor", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.Property<string>("Direccion")
                        .HasMaxLength(255);

                    b.Property<string>("Email");

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("Fechaingreso");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Ruc")
                        .HasMaxLength(13);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.HasKey("ProveedorId");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Proveedor_Lote", b =>
                {
                    b.Property<int>("Proveedor_LoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LoteId");

                    b.Property<int>("ProveedorId");

                    b.HasKey("Proveedor_LoteId");

                    b.HasIndex("LoteId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Proveedor_Lote");
                });

            modelBuilder.Entity("ServicuerosSA.Models.Sexo", b =>
                {
                    b.Property<int>("SexoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalle")
                        .IsRequired();

                    b.HasKey("SexoId");

                    b.ToTable("Sexo");
                });

            modelBuilder.Entity("ServicuerosSA.Models.TipoBodega", b =>
                {
                    b.Property<int>("TipoBodegaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalle");

                    b.HasKey("TipoBodegaId");

                    b.ToTable("TipoBodega");
                });

            modelBuilder.Entity("ServicuerosSA.Models.TipoPiel", b =>
                {
                    b.Property<int>("TipoPielId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalle");

                    b.HasKey("TipoPielId");

                    b.ToTable("TipoPiel");
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
                    b.HasOne("ServicuerosSA.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ServicuerosSA.Models.ApplicationUser")
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

                    b.HasOne("ServicuerosSA.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ServicuerosSA.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Bodega", b =>
                {
                    b.HasOne("ServicuerosSA.Models.TipoBodega", "TiposBodega")
                        .WithMany()
                        .HasForeignKey("TipoBodegaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Bodega1", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Bodega", "Bodegas")
                        .WithMany()
                        .HasForeignKey("BodegaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServicuerosSA.Models.Clasificacion", "Clasificaciones")
                        .WithMany()
                        .HasForeignKey("ClasificacionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServicuerosSA.Models.Lote", "Lotes")
                        .WithMany()
                        .HasForeignKey("LoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Lote", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("PersonalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServicuerosSA.Models.TipoPiel", "TipoPieles")
                        .WithMany()
                        .HasForeignKey("TipoPielId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Personal", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Sexo", "Sexo")
                        .WithMany()
                        .HasForeignKey("SexoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServicuerosSA.Models.Proveedor_Lote", b =>
                {
                    b.HasOne("ServicuerosSA.Models.Lote", "Lotes")
                        .WithMany()
                        .HasForeignKey("LoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServicuerosSA.Models.Proveedor", "Proveedores")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
