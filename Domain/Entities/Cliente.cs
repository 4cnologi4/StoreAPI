using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteArticulo = new HashSet<ClienteArticulo>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<ClienteArticulo> ClienteArticulo { get; set; }
    }
}
