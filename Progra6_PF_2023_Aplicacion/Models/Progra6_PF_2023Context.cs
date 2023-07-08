using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Progra6_PF_2023_Aplicacion.Models
{
    public partial class Progra6_PF_2023Context : DbContext
    {
        public Progra6_PF_2023Context()
        {
        }

        public Progra6_PF_2023Context(DbContextOptions<Progra6_PF_2023Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Abono> Abonos { get; set; } = null!;
        public virtual DbSet<Apartado> Apartados { get; set; } = null!;
        public virtual DbSet<ApartadosProducto> ApartadosProductos { get; set; } = null!;
        public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuarioRol> UsuarioRols { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("SERVER=.\\MSSQLSERVER01; DATABASE=Progra6_PF_2023; INTEGRATED SECURITY=FALSE; USER ID= Progra6_PF_2023_User;PASSWORD=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abono>(entity =>
            {
                entity.Property(e => e.AbonoId).HasColumnName("AbonoID");

                entity.Property(e => e.ApartadosId).HasColumnName("ApartadosID");

                entity.Property(e => e.FechaAbono).HasColumnType("date");

                entity.Property(e => e.MontoAbono).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Apartados)
                    .WithMany(p => p.Abonos)
                    .HasForeignKey(d => d.ApartadosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAbonos782815");
            });

            modelBuilder.Entity<Apartado>(entity =>
            {
                entity.HasKey(e => e.ApartadosId)
                    .HasName("PK__Apartado__3BA62D19CB7C846B");

                entity.Property(e => e.ApartadosId).HasColumnName("ApartadosID");

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaApartado).HasColumnType("date");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoUsuario)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Apartados)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKApartados574936");
            });

            modelBuilder.Entity<ApartadosProducto>(entity =>
            {
                entity.HasKey(e => new { e.ApartadosApartadosId, e.ProductoProductoId })
                    .HasName("PK__Apartado__3B311FFA52296EC9");

                entity.ToTable("Apartados_Producto");

                entity.Property(e => e.ApartadosApartadosId).HasColumnName("ApartadosApartadosID");

                entity.Property(e => e.ProductoProductoId).HasColumnName("ProductoProductoID");

                entity.Property(e => e.AbonoAgregado).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrecioOriginal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ApartadosApartados)
                    .WithMany(p => p.ApartadosProductos)
                    .HasForeignKey(d => d.ApartadosApartadosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKApartados_73225");

                entity.HasOne(d => d.ProductoProducto)
                    .WithMany(p => p.ApartadosProductos)
                    .HasForeignKey(d => d.ProductoProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKApartados_205534");
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.ToTable("Categoria producto");

                entity.Property(e => e.CategoriaProductoId).HasColumnName("CategoriaProductoID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CategoriaProductoId).HasColumnName("CategoriaProductoID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Stock)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Talla)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.CategoriaProducto)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKProducto731248");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.Property(e => e.Addres)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Avtivo)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.BackupEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");

                entity.HasOne(d => d.UsuarioRol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.UsuarioRolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUsuario73869");
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.ToTable("UsuarioRol");

                entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
