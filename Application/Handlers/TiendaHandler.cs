using Application.DTO;
using Application.Handlers.Interfaces;
using Application.Handlers.Request;
using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class TiendaHandler : ITiendaHandler
    {
        private readonly ITiendaRepository _tiendaRepository;

        public TiendaHandler(ITiendaRepository tiendaRepository)
        {
            _tiendaRepository = tiendaRepository;
        }

        public int AddTienda(TiendaRequest tiendaDto)
        {
            var tienda = new Tienda
            {
                Sucursal = tiendaDto.Sucursal,
                Direccion = tiendaDto.Direccion
            };
            return _tiendaRepository.AddTienda(tienda);
        }

        public bool UpdateTienda(int id, TiendaRequest tiendaDto)
        {
            var tienda = new Tienda
            {
                Sucursal = tiendaDto.Sucursal,
                Direccion = tiendaDto.Direccion
            };
            return _tiendaRepository.UpdateTienda(id, tienda);
        }

        public bool DeleteTienda(int id)
        {
            return _tiendaRepository.DeleteTienda(id);
        }

        public List<TiendaDto> GetAllTiendas()
        {
            var tiendas = _tiendaRepository.GetAllTiendas();
            return tiendas.Select(t => new TiendaDto(t)).ToList();
        }

        public TiendaDto GetTiendaById(int id)
        {
            var tienda = _tiendaRepository.GetTiendaById(id);
            if (tienda != null)
            {
                return new TiendaDto(tienda);
            }
            return null;
        }
    }
}
