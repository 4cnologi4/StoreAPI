using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Request
{
    public class TiendaRequest
    {
        public string? Sucursal { get; set; }
        public string? Direccion { get; set; }
    }
}
