using Application.DTO;
using Application.Handlers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Interfaces
{
    public interface ITiendaHandler
    {
        int AddTienda(TiendaRequest request);
        bool UpdateTienda(int id, TiendaRequest request);
        bool DeleteTienda(int id);
        List<TiendaDto> GetAllTiendas();
        TiendaDto GetTiendaById(int id);
    }
}
