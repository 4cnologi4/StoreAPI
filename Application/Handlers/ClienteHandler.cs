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
    public class ClienteHandler : IClienteHandler
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<ClienteDto> GetClientes()
        {
            var clientes = _clienteRepository.GetClientes();
            var clientesDto = new List<ClienteDto>();
            foreach (var cliente in clientes)
            {
                clientesDto.Add(new ClienteDto(cliente));
            }
            return clientesDto;
        }

        public ClienteDto GetClienteById(int id)
        {
            var cliente = _clienteRepository.GetClienteById(id);
            if (cliente != null)
            {
                return new ClienteDto(cliente);
            }
            return null;
        }

        public int AddCliente(ClienteRequest request)
        {
            var cliente = new Cliente
            {
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                Direccion = request.Direccion
            };
            return _clienteRepository.AddCliente(cliente);
        }

        public bool UpdateCliente(int id, ClienteRequest request)
        {
            var cliente = new Cliente
            {
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                Direccion = request.Direccion
            };
            return _clienteRepository.UpdateCliente(id, cliente);
        }

        public bool DeleteCliente(int id)
        {
            return _clienteRepository.DeleteCliente(id);
        }

    }
}
