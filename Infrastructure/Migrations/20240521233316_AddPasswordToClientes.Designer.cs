﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20240521233316_AddPasswordToClientes")]
    partial class AddPasswordToClientes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Articulo", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Domain.Entities.ArticuloTienda", b =>
                {
                    b.Property<int?>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int?>("TiendaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.HasKey("ArticuloId", "TiendaId");

                    b.HasIndex("TiendaId");

                    b.ToTable("Articulo_Tienda", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Domain.Entities.ClienteArticulo", b =>
                {
                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.HasKey("ClienteId", "ArticuloId");

                    b.HasIndex("ArticuloId");

                    b.ToTable("Cliente_Articulo", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tienda", b =>
                {
                    b.Property<int>("TiendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TiendaId"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Sucursal")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TiendaId")
                        .HasName("PK_Tienda");

                    b.ToTable("Tienda");
                });

            modelBuilder.Entity("Domain.Entities.ArticuloTienda", b =>
                {
                    b.HasOne("Domain.Entities.Articulo", "Articulo")
                        .WithMany("ArticuloTienda")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ArticuloTienda_Articulo");

                    b.HasOne("Domain.Entities.Tienda", "Tienda")
                        .WithMany("ArticuloTienda")
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ArticuloTienda_Tienda");

                    b.Navigation("Articulo");

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("Domain.Entities.ClienteArticulo", b =>
                {
                    b.HasOne("Domain.Entities.Articulo", "Articulo")
                        .WithMany("ClienteArticulo")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ClienteArticulo_Articulo");

                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("ClienteArticulo")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ClienteArticulo_Cliente");

                    b.Navigation("Articulo");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.Articulo", b =>
                {
                    b.Navigation("ArticuloTienda");

                    b.Navigation("ClienteArticulo");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("ClienteArticulo");
                });

            modelBuilder.Entity("Domain.Entities.Tienda", b =>
                {
                    b.Navigation("ArticuloTienda");
                });
#pragma warning restore 612, 618
        }
    }
}
