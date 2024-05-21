using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure
{
    public partial class StoreDbContext : DbContext
    {
        public StoreDbContext()
        {
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<ArticuloTienda> ArticuloTienda { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; } = null!;
        public virtual DbSet<Tienda> Tienda { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-ULRQ9UA0\\SQLEXPRESS;Database=Store;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.Codigo).HasMaxLength(50);
                entity.Property(e => e.Descripcion).HasMaxLength(255);
                entity.Property(e => e.Imagen).HasMaxLength(255);
                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ArticuloTienda>(entity =>
            {
                entity.HasKey(at => new { at.ArticuloId, at.TiendaId });

                entity.ToTable("Articulo_Tienda");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.ArticuloTienda)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ArticuloTienda_Articulo");

                entity.HasOne(d => d.Tienda)
                    .WithMany(p => p.ArticuloTienda)
                    .HasForeignKey(d => d.TiendaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ArticuloTienda_Tienda");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellidos).HasMaxLength(100);
                entity.Property(e => e.Direccion).HasMaxLength(255);
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<ClienteArticulo>(entity =>
            {
                entity.HasKey(ca => new { ca.ClienteId, ca.ArticuloId });

                entity.ToTable("Cliente_Articulo");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.ClienteArticulo)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ClienteArticulo_Articulo");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.ClienteArticulo)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ClienteArticulo_Cliente");
            });

            modelBuilder.Entity<Tienda>(entity =>
            {
                entity.HasKey(e => e.TiendaId)
                    .HasName("PK_Tienda");

                entity.Property(e => e.Direccion).HasMaxLength(255);
                entity.Property(e => e.Sucursal).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
