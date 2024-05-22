using Application.DTO;
using Application.Handlers.Interfaces;
using Application.Handlers.Request;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class ClienteHandler : IClienteHandler
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IConfiguration _configuration;

        public ClienteHandler(IClienteRepository clienteRepository, IConfiguration configuration)
        {
            _clienteRepository = clienteRepository;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateAsync(string nombre, string password)
        {
            var cliente = await _clienteRepository.GetClienteByCredentialsAsync(nombre, password);
            if (cliente == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, cliente.Nombre),
                    // Add more claims as needed
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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
