using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITiendaRepository
    {
        int AddTienda(Tienda tienda);
        bool UpdateTienda(int id, Tienda tienda);
        bool DeleteTienda(int id);
        List<Tienda> GetAllTiendas();
        Tienda GetTiendaById(int id);
    }
}
