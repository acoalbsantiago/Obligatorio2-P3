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
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private IResetearPassword _resetearPassword;
        private IObtenerUsuarios _obtenerUsuarios;
        public UsuarioController(IResetearPassword resetearPassword, IObtenerUsuarios obtenerUsuarios) 
        {
            _resetearPassword = resetearPassword;
            _obtenerUsuarios = obtenerUsuarios;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> ObtenerUsuarios()
        {
            return Ok(_obtenerUsuarios.ObtenerUsuarios());
        }

        [HttpPut("ResetPassword/{usuarioId}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult ResetearPassword(int usuarioId)
        {
            try
            {   
                string nuevaPass = _resetearPassword.ResetearPassword(usuarioId);
                return Ok(new {Password = nuevaPass });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
