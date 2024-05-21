using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class ArticuloTienda
    {
        public int? ArticuloId { get; set; }
        public int? TiendaId { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Articulo? Articulo { get; set; }
        public virtual Tienda? Tienda { get; set; }
    }
}
