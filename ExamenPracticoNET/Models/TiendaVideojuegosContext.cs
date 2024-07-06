using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamenPractico.Models;

public partial class TiendaVideojuegosContext : DbContext
{
    public TiendaVideojuegosContext()
    {
    }

    public TiendaVideojuegosContext(DbContextOptions<TiendaVideojuegosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>
		{
			new Categoria { CveCategoria = 1, NombreCategoria = "Aventura" },
			new Categoria { CveCategoria = 2, NombreCategoria = "Deportes" },
			new Categoria { CveCategoria = 3, NombreCategoria = "Estrategia" },
			new Categoria { CveCategoria = 4, NombreCategoria = "Rol" },
			new Categoria { CveCategoria = 5, NombreCategoria = "Shooter" }
		};

        List<Producto> productosInit = new List<Producto>
        {
            new Producto { CveProducto = 1, CveCategoria = 4, Nombre = "The Legend of Zelda: Breath of the Wild", Descripcion = "Juego de aventuras", Precio = 60, Imagen = "zelda.jpg" },
            new Producto { CveProducto = 2, CveCategoria = 5, Nombre = "FIFA 21", Descripcion = "Juego de futbol", Precio = 70, Imagen = "fifa21.jpg" },
            new Producto { CveProducto = 3, CveCategoria = 6, Nombre = "Age of Empires II: Definitive Edition", Descripcion = "Juego de estrategia", Precio = 20, Imagen = "ageofempires.jpg" },
            new Producto { CveProducto = 4, CveCategoria = 7, Nombre = "The Witcher 3: Wild Hunt", Descripcion = "Juego de rol", Precio = 40, Imagen = "witcher3.jpg" },
            new Producto { CveProducto = 5, CveCategoria = 8, Nombre = "Call of Duty: Warzone", Descripcion = "Juego de disparos", Precio = 0, Imagen = "codwarzone.jpg" }
        };

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CveCategoria);

            entity.ToTable("categoria");

            entity.Property(e => e.CveCategoria).HasColumnName("cve_categoria");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_categoria");
            entity.HasData(categoriasInit);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CveProducto);

            entity.ToTable("Producto");

            entity.Property(e => e.CveProducto).HasColumnName("cve_producto");
            entity.Property(e => e.CveCategoria).HasColumnName("cve_categoria");
            entity.HasOne(d => d.Categoria)
				.WithMany(p => p.Productos)
				.HasForeignKey(d => d.CveCategoria)
				.HasConstraintName("FK_Producto_categoria");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Imagen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precio");
            entity.HasData(productosInit);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
