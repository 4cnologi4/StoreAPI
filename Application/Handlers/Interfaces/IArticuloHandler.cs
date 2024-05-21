using Application.DTO;
using Application.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Interfaces
{
    public interface IArticuloHandler
    {
        int AddArticulo(ArticuloRequest articuloDto);
        bool UpdateArticulo(int id, ArticuloRequest articuloDto);
        bool DeleteArticulo(int id);
        List<ArticuloDto> GetAllArticulos();
        ArticuloDto GetArticuloById(int id);
    }
}
