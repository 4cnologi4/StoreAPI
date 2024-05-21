using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class ClienteArticulo
    {
        public int? ClienteId { get; set; }
        public int? ArticuloId { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Articulo? Articulo { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}
