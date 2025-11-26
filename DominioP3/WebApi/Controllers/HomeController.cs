using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private TokenHandler _token;
        private ILogin _login;
        
        public HomeController(ILogin login, TokenHandler token) 
        {
            _login = login;
            _token = token;
        }
       
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null) return BadRequest("Datos de login incorrectos");

            try
            {
                UsuarioDTO usuario = this._login.Login(loginDTO.Email, loginDTO.Password);
                string t = _token.GenerarToken(usuario);
                usuario.Token = t;
                return Ok(usuario);

            }
            catch(UsuarioException uex)
            {
                return NotFound(uex.Message);
            }
            catch (Exception){
                return StatusCode (500, "Error interno del servidor.");
            }                      
        }
    }
}
