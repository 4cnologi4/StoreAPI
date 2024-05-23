using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    public class DataInitializer
    {
        public static void Initialize(StoreDbContext context)
        {
            context.Clientes.AddRange(
            new Cliente { ClienteId = 1, Nombre = "Juan", Apellidos = "Perez", Direccion = "Calle Falsa 123", Password = "123" },
            new Cliente { ClienteId = 2, Nombre = "Ana", Apellidos = "Garcia", Direccion = "Calle Verdadera 456", Password = "456" }
            // Agregar más datos de ejemplo aquí
        );

            context.Tienda.AddRange(
                new Tienda { TiendaId = 1, Sucursal = "Centro", Direccion = "Calle Principal 789" },
                new Tienda { TiendaId = 2, Sucursal = "Norte", Direccion = "Avenida Secundaria 101" }
                // Agregar más datos de ejemplo aquí
            );

            context.Articulos.AddRange(
                new Articulo { ArticuloId = 1, Codigo = "A001", Descripcion = "Laptop", Precio = 1500.00M, Stock = 10 },
                new Articulo { ArticuloId = 2, Codigo = "A002", Descripcion = "Mouse", Precio = 20.00M, Stock = 100 }
                // Agregar más datos de ejemplo aquí
            );

            context.ArticuloTienda.AddRange(
                new ArticuloTienda { ArticuloId = 1, TiendaId = 1, Fecha = DateTime.Now },
                new ArticuloTienda { ArticuloId = 2, TiendaId = 2, Fecha = DateTime.Now }
                // Agregar más datos de ejemplo aquí
            );

            context.ClienteArticulos.AddRange(
                new ClienteArticulo { ClienteId = 1, ArticuloId = 1, Fecha = DateTime.Now },
                new ClienteArticulo { ClienteId = 2, ArticuloId = 2, Fecha = DateTime.Now }
            // Agregar más datos de ejemplo aquí
            );
            context.SaveChanges();
        }
    }
}
