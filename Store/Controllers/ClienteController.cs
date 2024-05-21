using Application.DTO;
using Application.Handlers.Interfaces;
using Application.Handlers.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteHandler _clienteHandler;

        public ClienteController(IClienteHandler clienteHandler)
        {
            _clienteHandler = clienteHandler;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _clienteHandler.GetClientes();
            if (clientes == null)
            {
                return NotFound();
            }
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            var cliente = _clienteHandler.GetClienteById(id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound("Cliente no encontrado.");
        }

        [HttpPost]
        public IActionResult AddCliente(ClienteRequest request)
        {
            var clienteId = _clienteHandler.AddCliente(request);
            if (clienteId != -1)
            {
                return Ok(clienteId);
            }
            return BadRequest("Error al agregar el cliente.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, ClienteRequest request)
        {
            var result = _clienteHandler.UpdateCliente(id, request);
            if (result)
            {
                return Ok("Cliente actualizado correctamente.");
            }
            return NotFound("Cliente no encontrado.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var result = _clienteHandler.DeleteCliente(id);
            if (result)
            {
                return Ok("Cliente eliminado correctamente.");
            }
            return NotFound("Cliente no encontrado.");
        }       

    }
}
