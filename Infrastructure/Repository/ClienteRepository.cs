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
    public class ClienteRepository : IClienteRepository
    {
        private readonly StoreDbContext _context;

        public ClienteRepository(StoreDbContext context)
        {
            _context = context;
        }

        public List<Cliente> GetClientes()
        {
            try
            {
                var clientes = _context.Clientes.ToList();
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente GetClienteById(int id)
        {
            try
            {
                return _context.Clientes.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int AddCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return cliente.ClienteId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public bool UpdateCliente(int id, Cliente cliente)
        {
            try
            {
                var existingCliente = _context.Clientes.Find(id);
                if (existingCliente != null)
                {
                    existingCliente.Nombre = cliente.Nombre;
                    existingCliente.Apellidos = cliente.Apellidos;
                    existingCliente.Direccion = cliente.Direccion;

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

        public bool DeleteCliente(int id)
        {
            try
            {
                var cliente = _context.Clientes.Find(id);
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
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
    }
}
