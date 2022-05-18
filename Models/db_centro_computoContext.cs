using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAppCentroComputo.Models
{
    public partial class db_centro_computoContext : DbContext
    {
        public db_centro_computoContext()
        {
        }

        public db_centro_computoContext(DbContextOptions<db_centro_computoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-C65R4E1\\SQLEXPRESS;Initial Catalog=db_centro_computo;User ID=admin;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCateg)
                    .HasName("PK__Categori__D2408AAD6559E1D3");

                entity.Property(e => e.IdCateg)
                    .ValueGeneratedNever()
                    .HasColumnName("id_categ");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoria");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca__7E43E99E2F144C82");

                entity.ToTable("Marca");

                entity.Property(e => e.IdMarca)
                    .ValueGeneratedNever()
                    .HasColumnName("id_marca");

                entity.Property(e => e.Marca1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                    .HasName("PK__Producto__0DA348736383BE40");

                entity.Property(e => e.IdProd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_prod");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdCateg).HasColumnName("id_categ");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdCategNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCateg)
                    .HasConstraintName("FK__Productos__id_ca__2C3393D0");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__Productos__id_ma__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
