using LogicaDeAplicacion.InterfacesCU.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IResetearPassword _resetearPassword;
        public UsuarioController(IResetearPassword resetearPassword) 
        {
            _resetearPassword = resetearPassword;
        }
        [HttpPost("ResetPassword/{usuarioId}")]
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
