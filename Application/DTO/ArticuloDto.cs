using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ArticuloDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public int? TiendaId { get; set; }
        public string? TiendaNombre { get; set; }

        public ArticuloDto() { }

        public ArticuloDto(Articulo articulo)
        {
            Id = articulo.ArticuloId;
            Codigo = articulo.Codigo;
            Descripcion = articulo.Descripcion;
            Precio = articulo.Precio;
            Imagen = articulo.Imagen;
            Stock = articulo.Stock;

            var articuloTienda = articulo.ArticuloTienda.FirstOrDefault();
            if (articuloTienda != null)
            {
                TiendaId = articuloTienda.TiendaId;
                TiendaNombre = articuloTienda.Tienda?.Sucursal;
            }
        }
    }
}
