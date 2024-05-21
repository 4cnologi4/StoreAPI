using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Tienda
    {
        public Tienda()
        {
            ArticuloTienda = new HashSet<ArticuloTienda>();
        }

        public int TiendaId { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<ArticuloTienda> ArticuloTienda { get; set; }
    }
}
