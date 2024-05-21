using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TiendaRepository : ITiendaRepository
    {
        private readonly StoreDbContext _context;

        public TiendaRepository(StoreDbContext context)
        {
            _context = context;
        }

        public int AddTienda(Tienda tienda)
        {
            try
            {
                _context.Tienda.Add(tienda);
                _context.SaveChanges();
                return tienda.TiendaId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public bool UpdateTienda(int id, Tienda tienda)
        {
            try
            {
                var existingTienda = _context.Tienda.Find(id);
                if (existingTienda != null)
                {
                    existingTienda.Sucursal = tienda.Sucursal;
                    existingTienda.Direccion = tienda.Direccion;

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteTienda(int id)
        {
            try
            {
                var tienda = _context.Tienda.Find(id);
                if (tienda != null)
                {
                    _context.Tienda.Remove(tienda);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Tienda> GetAllTiendas()
        {
            try
            {
                return _context.Tienda.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Tienda GetTiendaById(int id)
        {
            try
            {
                return _context.Tienda.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
