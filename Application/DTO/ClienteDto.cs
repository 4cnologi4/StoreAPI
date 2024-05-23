using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public List<ClienteArticuloDto> Articulos { get; set; }

        public ClienteDto() { }

        public ClienteDto(Cliente cliente)
        {
            Id = cliente.ClienteId;
            Nombre = cliente.Nombre;
            Password = cliente.Password;
            Apellidos = cliente.Apellidos;
            Direccion = cliente.Direccion;
            Articulos = cliente.ClienteArticulo.Select(ca => new ClienteArticuloDto(ca)).ToList();
        }
    }

    public class ClienteArticuloDto
    {
        public int? ArticuloId { get; set; }
        public string? ArticuloDescripcion { get; set; }
        public DateTime? Fecha { get; set; }

        public ClienteArticuloDto() { }

        public ClienteArticuloDto(ClienteArticulo clienteArticulo)
        {
            ArticuloId = clienteArticulo.ArticuloId;
            ArticuloDescripcion = clienteArticulo.Articulo?.Descripcion;
            Fecha = clienteArticulo.Fecha;
        }
    }
}
