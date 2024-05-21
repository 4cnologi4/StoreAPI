using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Articulo
    {
        public Articulo()
        {
            ArticuloTienda = new HashSet<ArticuloTienda>();
            ClienteArticulo = new HashSet<ClienteArticulo>();
        }

        public int ArticuloId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<ArticuloTienda> ArticuloTienda { get; set; }
        public virtual ICollection<ClienteArticulo> ClienteArticulo { get; set; }
    }
}
