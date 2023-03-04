using Gremlins.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gremlins.WebApi.DataAccess
{
    public partial class GremlinsDbContext : DbContext
    {
        public GremlinsDbContext()
        {
        }

        public GremlinsDbContext(DbContextOptions<GremlinsDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Distribuidores> Distribuidores { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
        public virtual DbSet<VentasDetalles> VentasDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=*****;Database=*******; User Id=****; Password=*******;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente).ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Distribuidores>(entity =>
            {
                entity.HasKey(e => e.IdDistribuidor);

                entity.Property(e => e.IdDistribuidor).ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentoIdentidad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefonico).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdProducto).ValueGeneratedNever();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Existencias).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PorcentajeDescuento).HasColumnType("numeric(3, 2)");

                entity.Property(e => e.Precio).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdDistribuidorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdDistribuidor)
                    .HasConstraintName("FK_Productos_Distribuidores");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.IdRol).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Usuarios_Roles");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.IdVenta);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.ValorTotal).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Habilitado).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Ventas_Clientes");
            });

            modelBuilder.Entity<VentasDetalles>(entity =>
            {
                entity.HasKey(e => e.IdDetalleVenta);

                entity.HasIndex(e => e.IdVenta, "IX_VentasDetalles");

                entity.Property(e => e.Cantidad).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Precio).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.Habilitado).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.VentasDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_VentasDetalles_Productos");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.VentasDetalles)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentasDetalles_Ventas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
