using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly StoreDbContext _context;

        public ArticuloRepository(StoreDbContext context)
        {
            _context = context;
        }

        public int AddArticulo(Articulo articulo, int tiendaId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Articulos.Add(articulo);
                _context.SaveChanges();

                var articuloTienda = new ArticuloTienda
                {
                    ArticuloId = articulo.ArticuloId,
                    TiendaId = tiendaId,
                    Fecha = DateTime.Now
                };
                _context.ArticuloTienda.Add(articuloTienda);
                _context.SaveChanges();

                transaction.Commit();
                return articulo.ArticuloId;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return -1;
            }
        }

        public bool UpdateArticulo(int id, Articulo articulo, int tiendaId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var existingArticulo = _context.Articulos.Find(id);
                if (existingArticulo != null)
                {
                    existingArticulo.Descripcion = articulo.Descripcion;
                    existingArticulo.Precio = articulo.Precio;
                    existingArticulo.Imagen = articulo.Imagen;
                    existingArticulo.Stock = articulo.Stock;

                    var articuloTienda = _context.ArticuloTienda.FirstOrDefault(at => at.ArticuloId == id);
                    if (articuloTienda != null)
                    {
                        //articuloTienda.TiendaId = tiendaId;
                        articuloTienda.Fecha = DateTime.Now;
                    }
                    else
                    {
                        _context.ArticuloTienda.Add(new ArticuloTienda
                        {
                            ArticuloId = id,
                            TiendaId = tiendaId,
                            Fecha = DateTime.Now
                        });
                    }

                    _context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool DeleteArticulo(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var articulo = _context.Articulos.Find(id);
                if (articulo != null)
                {
                    var articuloTienda = _context.ArticuloTienda.Where(at => at.ArticuloId == id);
                    _context.ArticuloTienda.RemoveRange(articuloTienda);

                    _context.Articulos.Remove(articulo);
                    _context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }

        public List<Articulo> GetAllArticulos()
        {
            try
            {
                var articulos = _context.Articulos
                    .Include(a => a.ArticuloTienda)
                    .ThenInclude(at => at.Tienda)
                    .ToList();

                return articulos ?? new List<Articulo>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Articulo GetArticuloById(int id)
        {
            try
            {
                var articulo = _context.Articulos
                    .Include(a => a.ArticuloTienda)
                    .ThenInclude(at => at.Tienda)
                    .FirstOrDefault();
                return articulo ?? new Articulo();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
