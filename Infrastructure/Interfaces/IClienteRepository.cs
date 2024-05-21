using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IClienteRepository
    {
        public List<Cliente> GetClientes();
        public Cliente GetClienteById(int id);
        public int AddCliente(Cliente cliente);
        public bool UpdateCliente(int id, Cliente cliente);
        public bool DeleteCliente(int id);
    }
}
