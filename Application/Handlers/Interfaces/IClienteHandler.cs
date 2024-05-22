using Application.DTO;
using Application.Handlers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Interfaces
{
    public interface IClienteHandler
    {
        public Task<string> AuthenticateAsync(string nombre, string password);
        public List<ClienteDto> GetClientes();
        public ClienteDto GetClienteById(int id);
        public int AddCliente(ClienteRequest request);
        public bool UpdateCliente(int id, ClienteRequest request);
        public bool DeleteCliente(int id);
    }
}
