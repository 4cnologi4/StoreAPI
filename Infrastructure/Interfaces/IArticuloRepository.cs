using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IArticuloRepository
    {
        int AddArticulo(Articulo articulo, int tiendaId);
        bool UpdateArticulo(int id, Articulo articulo, int tiendaId);
        bool DeleteArticulo(int id);
        List<Articulo> GetAllArticulos();
        Articulo GetArticuloById(int id);
    }
}
