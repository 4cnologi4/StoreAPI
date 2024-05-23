using Application.DTO;
using Application.Handlers;
using Application.Handlers.Interfaces;
using Application.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArticuloController : Controller
    {
        private readonly IArticuloHandler _articuloHandler;

        public ArticuloController(IArticuloHandler articuloHandler)
        {
            _articuloHandler = articuloHandler;
        }

        [HttpPost]
        public IActionResult AddArticulo([FromBody] ArticuloRequest request)
        {
            var articuloId = _articuloHandler.AddArticulo(request);
            if (articuloId != -1)
            {
                return Ok(articuloId);
            }
            return BadRequest("Error al agregar el artículo.");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateArticulo(int id, [FromBody] ArticuloRequest request)
        {
            var result = _articuloHandler.UpdateArticulo(id, request);
            if (result)
            {
                return Ok(new { message = "Artículo actualizado correctamente." });
            }
            return NotFound("Artículo no encontrado.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticulo(int id)
        {
            var result = _articuloHandler.DeleteArticulo(id);
            if (result)
            {
                return Ok(new { message = "Artículo eliminado correctamente." });
            }
            return NotFound("Artículo no encontrado.");
        }

        [HttpGet]
        public IActionResult GetAllArticulos()
        {
            var articulos = _articuloHandler.GetAllArticulos();
            if (articulos != null && articulos.Any())
            {
                return Ok(articulos);
            }
            return NotFound("No se encontraron artículos.");
        }

        [HttpGet("{id}")]
        public IActionResult GetArticuloById(int id)
        {
            var cliente = _articuloHandler.GetArticuloById(id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound("Artículo no encontrado.");
        }

    }
}
