using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TiendaDto
    {
        public int TiendaId { get; set; }
        public string? Sucursal { get; set; }
        public string? Direccion { get; set; }

        public TiendaDto() { }

        public TiendaDto(Tienda tienda)
        {
            TiendaId = tienda.TiendaId;
            Sucursal = tienda.Sucursal;
            Direccion = tienda.Direccion;
        }
    }
}
