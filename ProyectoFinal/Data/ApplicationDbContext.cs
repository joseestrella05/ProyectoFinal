using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace ProyectoFinal.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{

    public DbSet<CategoriaProductos> CategoriaProductos { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Ordenes> Ordenes { get; set; }
    public DbSet<OrdenesDetalle> OrdenesDetalle { get; set; }
    public DbSet<Ventas> Ventas { get; set; }
    public DbSet<VentasDetalle> VentasDetalle { get; set; }
    public DbSet<Estados> Estados { get; set; }
    public DbSet<MetodoPagos> MetodoPagos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ConfigureGeneralModel(modelBuilder);
        ConfigureProductosModel(modelBuilder);

        // Configurar las relaciones
        modelBuilder.Entity<Ordenes>()
            .HasMany(o => o.OrdenesDetalle)
            .WithOne(d => d.Orden)
            .HasForeignKey(d => d.OrdenId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrdenesDetalle>()
            .HasOne(d => d.Producto)
            .WithMany()
            .HasForeignKey(d => d.ProductoId);
    }

    public void ConfigureGeneralModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estados>().HasData(
             new Estados { EstadoId = 1, NombreEstado = "Pendiente" },
             new Estados { EstadoId = 2, NombreEstado = "Preparando" },
             new Estados { EstadoId = 3, NombreEstado = "YA ESTÁ LISTA" },
             new Estados { EstadoId = 4, NombreEstado = "Cancelado" }
        );
        modelBuilder.Entity<MetodoPagos>().HasData(
             new MetodoPagos { MetodoPagoId = 1, Nombre = "Efectivo" },
             new MetodoPagos { MetodoPagoId = 2, Nombre = "Tarjeta" }
        );
        modelBuilder.Entity<CategoriaProductos>().HasData(
             new CategoriaProductos { CategoriaId = 1, Nombre = "Pizza" },
             new CategoriaProductos { CategoriaId = 2, Nombre = "Bebidas" }
             
        );
    }

    public void ConfigureProductosModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Productos>().HasData(
            new Productos { Nombre = "Gran Pepperoni", Cantidad = 50, Precio = 475, ITBIS = 85.5f, ProductoId = 1, CategoriaId = 1, Disponible = true, Descripcion = "Pizza clásica con doble pepperoni, mozzarella y salsa de tomate sobre masa artesanal.", ImagenUrl = "/images/Peperonni.jpg" },
            new Productos { Nombre = "Jamón Deluxe", Cantidad = 50, Precio = 500, ITBIS = 90.0f, ProductoId = 2, CategoriaId = 1, Disponible = true, Descripcion = "Deliciosa pizza con jamón ahumado, queso mozzarella y un toque de albahaca fresca.", ImagenUrl = "/images/JamonDeluxe.jpg" },
            new Productos { Nombre = "Pizza Mixta", Cantidad = 50, Precio = 450, ITBIS = 72.0f, ProductoId = 3, CategoriaId = 1, Disponible = true, Descripcion = "Una mezcla perfecta de carnes, vegetales frescos, mozzarella y orégano.", ImagenUrl = "/images/Mixta.jpg" },
            new Productos { Nombre = "Hawaiana", Cantidad = 50, Precio = 325, ITBIS = 58.5f, ProductoId = 4, CategoriaId = 1, Disponible = true, Descripcion = "Pizza dulce y salada con jamón, piña, mozzarella y salsa de tomate.", ImagenUrl = "/images/Hawaiana.jpg" },
            new Productos { Nombre = "Familiar Especial", Cantidad = 50, Precio = 425, ITBIS = 76.5f, ProductoId = 5, CategoriaId = 1, Disponible = true, Descripcion = "Ideal para compartir, con múltiples ingredientes: pepperoni, jamón, champiñones y más.", ImagenUrl = "/images/FamiliarEspecial.jpg" },
            new Productos { Nombre = "Individual Italiana", Cantidad = 50, Precio = 400, ITBIS = 72.0f, ProductoId = 6, CategoriaId = 1, Disponible = true, Descripcion = "Pizza personal con ingredientes clásicos italianos: tomate, mozzarella y albahaca.", ImagenUrl = "/images/IndividualItaliana.jpg" },
            new Productos { Nombre = "Vegetariana", Cantidad = 50, Precio = 500, ITBIS = 90.0f, ProductoId = 7, CategoriaId = 1, Disponible = true, Descripcion = "Cargada de vegetales frescos como pimientos, champiñones, cebolla y espinacas.", ImagenUrl = "/images/Vegetariana.jpg" },
            new Productos { Nombre = "Barbacoa (BBQ)", Cantidad = 50, Precio = 350, ITBIS = 63.0f, ProductoId = 8, CategoriaId = 1, Disponible = true, Descripcion = "Sabor ahumado con carne de cerdo desmechada, cebolla caramelizada y salsa BBQ.", ImagenUrl = "/images/Barbacoa(BBQ).jpg" },
            new Productos { Nombre = "Napolitana", Cantidad = 50, Precio = 375, ITBIS = 67.5f, ProductoId = 9, CategoriaId = 1, Disponible = true, Descripcion = "La tradición napolitana con tomates frescos, mozzarella y aceite de oliva.", ImagenUrl = "/images/Napolitana.jpg" },
            new Productos { Nombre = "Cuatro Quesos", Cantidad = 50, Precio = 500, ITBIS = 90.0f, ProductoId = 10, CategoriaId = 1, Disponible = true, Descripcion = "Una mezcla de quesos irresistibles: mozzarella, parmesano, gorgonzola y ricotta.", ImagenUrl = "/images/CuatroQuesos.jpg" },
            new Productos { Nombre = "Agua", Cantidad = 50, Precio = 20, ITBIS = 3.6f, ProductoId = 14, CategoriaId = 2, Disponible = true, Descripcion = "Botella de agua fría, ideal para acompañar cualquier pizza.", ImagenUrl = "/images/Agua.jpg" },
            new Productos { Nombre = "Coca Cola 500ml", Cantidad = 50, Precio = 50, ITBIS = 9.0f, ProductoId = 15, CategoriaId = 2, Disponible = true, Descripcion = "Refresco clásico de Coca Cola en presentación de 500ml.", ImagenUrl = "/images/CocaCola.jpg" }
        );
    }
}
