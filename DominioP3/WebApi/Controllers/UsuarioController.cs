using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMINISTRADOR")]
    public class UsuarioController : ControllerBase
    {
        private IResetearPassword _resetearPassword;
        private IObtenerUsuarios _obtenerUsuarios;
        public UsuarioController(IResetearPassword resetearPassword, IObtenerUsuarios obtenerUsuarios) 
        {
            _resetearPassword = resetearPassword;
            _obtenerUsuarios = obtenerUsuarios;
        }

        [ProducesResponseType(typeof(IEnumerable<UsuarioDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> ObtenerUsuarios()
        {
            return Ok(_obtenerUsuarios.ObtenerUsuarios());
        }


        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("ResetPassword/{usuarioId}")]
        public IActionResult ResetearPassword(int usuarioId)
        {
            try
            {   
                string nuevaPass = _resetearPassword.ResetearPassword(usuarioId);
                return Ok(new {Password = nuevaPass });
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }            
        }
    }
}
