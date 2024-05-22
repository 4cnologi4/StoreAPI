using Application.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IClienteHandler _clienteHandler;

        public AuthController(IClienteHandler clienteHandler)
        {
            _clienteHandler = clienteHandler;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            var token = await _clienteHandler.AuthenticateAsync(request.Nombre, request.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }

    public class AuthenticateRequest
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
    }
}
