using Application.DTO;
using Application.Handlers.Interfaces;
using Application.Request;
using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class ArticuloHandler : IArticuloHandler
    {
        private readonly IArticuloRepository _articuloRepository;

        public ArticuloHandler(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public int AddArticulo(ArticuloRequest request)
        {
            var articulo = new Articulo
            {
                Descripcion = request.Descripcion,
                Precio = request.Precio,
                Imagen = request.Imagen,
                Stock = request.Stock
            };
            return _articuloRepository.AddArticulo(articulo, request.TiendaId);
        }

        public bool UpdateArticulo(int id, ArticuloRequest request)
        {
            var articulo = new Articulo
            {
                ArticuloId = id,
                Descripcion = request.Descripcion,
                Precio = request.Precio,
                Imagen = request.Imagen,
                Stock = request.Stock
            };
            return _articuloRepository.UpdateArticulo(id, articulo, request.TiendaId);
        }

        public bool DeleteArticulo(int id)
        {
            return _articuloRepository.DeleteArticulo(id);
        }

        public List<ArticuloDto> GetAllArticulos()
        {
            var articulos = _articuloRepository.GetAllArticulos();
            return articulos.Select(a => new ArticuloDto(a)).ToList();
        }

        public ArticuloDto GetArticuloById(int id)
        {
            var articulo = _articuloRepository.GetArticuloById(id);
            if (articulo != null)
            {
                return new ArticuloDto(articulo);
            }
            return null;
        }

    }
}
