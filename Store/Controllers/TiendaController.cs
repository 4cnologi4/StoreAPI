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
    public class TiendaController : ControllerBase
    {
        private readonly ITiendaHandler _tiendaHandler;

        public TiendaController(ITiendaHandler tiendaHandler)
        {
            _tiendaHandler = tiendaHandler;
        }

        [HttpPost]
        public IActionResult AddTienda(TiendaRequest request)
        {
            var tiendaId = _tiendaHandler.AddTienda(request);
            if (tiendaId != -1)
            {
                return Ok(tiendaId);
            }
            return BadRequest("Error al agregar la tienda.");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateTienda(int id, TiendaRequest request)
        {
            var result = _tiendaHandler.UpdateTienda(id, request);
            if (result)
            {
                return Ok("Tienda actualizada correctamente.");
            }
            return NotFound("Tienda no encontrada.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTienda(int id)
        {
            var result = _tiendaHandler.DeleteTienda(id);
            if (result)
            {
                return Ok("Tienda eliminada correctamente.");
            }
            return NotFound("Tienda no encontrada.");
        }

        [HttpGet]
        public IActionResult GetAllTiendas()
        {
            var tiendas = _tiendaHandler.GetAllTiendas();
            if (tiendas != null && tiendas.Any())
            {
                return Ok(tiendas);
            }
            return NotFound("No se encontraron tiendas.");
        }

        [HttpGet("{id}")]
        public IActionResult GetTiendaById(int id)
        {
            var tienda = _tiendaHandler.GetTiendaById(id);
            if (tienda != null)
            {
                return Ok(tienda);
            }
            return NotFound("Tienda no encontrada.");
        }

    }
}
